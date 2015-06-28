using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels
{
    public class MatchDetailsViewModel : IMapFrom<Match>, IHaveCustomMappings
    {

        public int Id { get; set; }

        [Display(Name = "Home Team")]
        public string HomeTeamName { get; set; }
        public Team HomeTeam { get; set; }
        public int HomeTeamId { get; set; }

        [Display(Name = "Away Team")]
        public string AwayTeamName { get; set; }
        public Team AwayTeam { get; set; }
        public int AwayTeamId { get; set; }

        [Display(Name = "Date and Time")]
        public DateTime DateTime { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public decimal AwayBet { get; set; }

        public decimal HomeBet { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchDetailsViewModel>()
                .ForMember(x => x.HomeTeamName, cnf => cnf.MapFrom(u => u.HomeTeam.Name))
                .ForMember(x => x.AwayTeamName, cnf => cnf.MapFrom(u => u.AwayTeam.Name))
                .ForMember(x => x.AwayBet, m => m.MapFrom(y => y.Bets.Any() ? y.Bets.Sum(v => v.AwayBet) : 0))
                .ForMember(x => x.HomeBet, m => m.MapFrom(y => y.Bets.Any() ? y.Bets.Sum(v => v.HomeBet) : 0));
        }

        
       

    }
}