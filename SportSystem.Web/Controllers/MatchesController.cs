using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using PagedList;
using SportSystem.Data;
using SportSystem.Models;
using SportSystem.Web.InputModels;
using SportSystem.Web.ViewModels;

namespace SportSystem.Web.Controllers
{

    [Authorize]
    public class MatchesController : BaseController
    {
        private const int DefaultPageSize = 6;
        private const int DefaultPageNumber = 1;

        public MatchesController(ISportSystemData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var matches = this.Data.Matches
                 .All()
                 .OrderBy(x=>x.DateTime)
                 .Project()
                 .To<TopMachesViewModel>()
                 .ToPagedList(page ?? DefaultPageNumber, DefaultPageSize);

            return this.View(matches);
        }

        public ActionResult Details(int id)
        {
            var match = this.Data.Matches
                .All()
                .Where(x => x.Id == id)
                .Project()
                .To<MatchDetailsViewModel>()
                .FirstOrDefault();

            if (match != null)
            {
                return this.View(match);
            }

            // TODO: Add error
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.UserId = this.User.Identity.GetUserId();
                comment.DateTime = DateTime.Now;
                var newcomment = comment;
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentViewModel = this.Data.Comments
                    .All()
                    .Where(x => x.Id == comment.Id)
                    .Project()
                    .To<CommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentViewModel", commentViewModel);
            }

            return this.Json(this.ModelState);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bet(BetInputModel model)
        {
            if (model.HomeBet != 0 && model.AwayBet == 0)
            {
                var homeBetToDb = Mapper.Map<Bet>(model);
                homeBetToDb.AwayBet = 0;
                homeBetToDb.UserId = this.User.Identity.GetUserId();

                this.Data.Bets.Add(homeBetToDb);
                this.Data.SaveChanges();

                var homeBetFromDb = this.Data.Bets
                    .All()
                    .Where(x => x.MatchId == model.MatchId)
                    .Sum(x => x.HomeBet);

                return this.Content(homeBetFromDb.ToString());
            }

            if (model.HomeBet == 0 && model.AwayBet != 0)
            {
                var awayBetToDb = Mapper.Map<Bet>(model);
                awayBetToDb.HomeBet = 0;
                awayBetToDb.UserId = this.User.Identity.GetUserId();

                this.Data.Bets.Add(awayBetToDb);
                this.Data.SaveChanges();

                var awayBetFromDb = this.Data.Bets
                    .All()
                    .Where(x => x.MatchId == model.MatchId)
                    .Sum(x => x.AwayBet);

                return this.Content(awayBetFromDb.ToString());
            }

            return this.Json(this.ModelState, JsonRequestBehavior.AllowGet);
        }
    }
}