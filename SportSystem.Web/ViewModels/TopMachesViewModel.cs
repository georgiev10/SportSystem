using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels
{
    public class TopMachesViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }
        
        public DateTime DateTime { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Match, TopMachesViewModel>()
                .ForMember(x => x.HomeTeamName, cnf => cnf.MapFrom(u => u.HomeTeam.Name))
                .ForMember(x => x.AwayTeamName, cnf => cnf.MapFrom(u => u.AwayTeam.Name));
        }
    }
}