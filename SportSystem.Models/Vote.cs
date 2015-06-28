using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SportSystem.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public virtual Team Team { get; set; }

        public int TeamId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
