using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using SportSystem.Data;
using SportSystem.Models;
using SportSystem.Web.Extensions;
using SportSystem.Web.InputModels;
using SportSystem.Web.ViewModels;

namespace SportSystem.Web.Controllers
{
    [Authorize]
    public class TeamsController : BaseController
    {
        public TeamsController(ISportSystemData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var team = this.Data.Teams
                .All()
                .Where(x => x.Id == id)
                .Project()
                .To<TeamDetailsViewModel>()
                .FirstOrDefault();

            var userId = this.User.Identity.GetUserId();

            var userHasVote = this.Data.Votes
                .All()
                .Any(x => x.TeamId == id && x.UserId == userId);

            if (team != null)
            {
                team.UserHasVote = userHasVote;
                return this.View(team);
            }

            return this.RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(VoteInputModel model)
        {
            if (this.Data.Votes.All().Any(x => x.TeamId == model.TeamId && x.UserId == model.UserId))
            {
                this.ModelState.AddModelError(string.Empty, "The user has already vote for this team.");
            }

            if (model != null && this.ModelState.IsValid)
            {
                var vote = Mapper.Map<Vote>(model);
                vote.Value = 1;

                this.Data.Votes.Add(vote);
                this.Data.SaveChanges();

                var votesCount = this.Data.Votes
                    .All()
                    .Where(x => x.TeamId == model.TeamId)
                    .Sum(x => x.Value);
                return this.Content(votesCount.ToString());
            }

            return this.Json(this.ModelState, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            LoadUnemploymentPlayers();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTeamInputModel model)
        {
            if (model !=null && this.ModelState.IsValid)
            {
                var teamToDb = Mapper.Map<Team>(model);
                this.Data.Teams.Add(teamToDb);
                this.Data.SaveChanges();

                foreach (var playerId in model.PlayerIds)
                {
                    if (playerId != 0)
                    {
                        var player = this.Data.Players.Find(playerId);
                        player.TeamId = teamToDb.Id;
                        this.Data.SaveChanges();
                    }
                }

                return this.RedirectToAction("Details", new {id = teamToDb.Id});
            }

            LoadUnemploymentPlayers();
            return this.View();
        }

        public ActionResult GetPlayerInput()
        {
            this.LoadUnemploymentPlayers();
            return this.PartialView("_CreatePlayer");
        }

        private void LoadUnemploymentPlayers()
        {
            this.ViewBag.Players = this.Data.Players
                .All()
                .Where(x => x.TeamId == null)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });

            this.ViewBag.Players = AddDefaultOption(this.ViewBag.Players, "None", "0");
        }



        private IEnumerable<SelectListItem> AddDefaultOption(IEnumerable<SelectListItem> list, 
            string dataTextField, string selectedValue)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = dataTextField,
                    Value = selectedValue,
                    Selected = true
                }
            };
            items.AddRange(list);
            return items;
        }



    }
}