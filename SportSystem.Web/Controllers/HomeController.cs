using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SportSystem.Data;
using SportSystem.Models;
using SportSystem.Web.ViewModels;

namespace SportSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data)
            : base(data)
        {
        }
        public ActionResult Index()
        {
            var topMaches = this.Data.Matches
                .All()
                .OrderByDescending(x => x.Bets.Sum(y => y.HomeBet) + x.Bets.Sum(y => y.AwayBet))
                .Take(3)
                .Project()
                .To<TopMachesViewModel>();

            var topTeams = this.Data.Teams
                .All()
                .OrderByDescending(x => x.Votes.Sum(y => y.Value))
                .Take(3)
                .Project()
                .To<TopTeamsViewModel>();


            return View(new HomeViewModel()
            {
                TopMaches = topMaches,
                TopTeams = topTeams
            });
        }


       
    }
}