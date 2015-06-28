using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SportSystem.Web.ViewModels
{
    public class PlayerViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Born")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public decimal Height { get; set; }
    }
}