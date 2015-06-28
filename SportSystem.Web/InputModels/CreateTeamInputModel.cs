using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.InputModels
{
    public class CreateTeamInputModel : IMapTo<Team>
    {
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The {0} should be between {2} {1}.")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "The {0} should be between {2} {1}.")]
        public string NickName { get; set; }

        [Url]
        public string WebSite { get; set; }

        public DateTime? DateFounded { get; set; }

        public IEnumerable<int> PlayerIds { get; set; }

    }
}