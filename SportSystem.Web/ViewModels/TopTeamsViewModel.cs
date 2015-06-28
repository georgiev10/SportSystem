using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels
{
    public class TopTeamsViewModel : IMapFrom<Team>, IHaveCustomMappings
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string WebSite { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TopTeamsViewModel>()
                .ForMember(x => x.Votes, cnf => cnf.MapFrom(u => u.Votes.Any() ? u.Votes.Sum(s => s.Value) : 0));
        }
    }
}