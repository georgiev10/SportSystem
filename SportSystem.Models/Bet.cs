using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSystem.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public virtual Match Match { get; set; }

        public int MatchId { get; set; }

        [Required]
        public decimal  HomeBet { get; set; }

        [Required]
        public decimal AwayBet { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
