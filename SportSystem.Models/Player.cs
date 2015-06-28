using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SportSystem.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        public decimal Height { get; set; }

        public virtual Team Team { get; set; }
       
        public int? TeamId { get; set; }
    }
}
