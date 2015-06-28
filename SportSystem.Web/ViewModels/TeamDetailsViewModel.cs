using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels
{
    public class TeamDetailsViewModel: IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string NickName { get; set; }

        public string WebSite { get; set; }

        [Display(Name = "Founded")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateFounded { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }

        public int Votes { get; set; }

        public bool UserHasVote { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamDetailsViewModel>()
                .ForMember(x => x.Votes, cnf => cnf.MapFrom(u => u.Votes.Any() ? u.Votes.Sum(s => s.Value) : 0));
        }

    }
}