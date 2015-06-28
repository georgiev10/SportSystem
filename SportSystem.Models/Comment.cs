using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace SportSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime DateTime { get; set; }
        
        public virtual User User { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual Match Match { get; set; }

        public int MatchId { get; set; }
    }
}
