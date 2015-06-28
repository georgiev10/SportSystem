using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSystem.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<TopMachesViewModel> TopMaches { get; set; }
        public IEnumerable<TopTeamsViewModel> TopTeams { get; set; }
    }
}

