using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSystem.Models
{
    public class Match
    {
        public Match()
        {
            this.Comments = new HashSet<Comment>();
            this.Bets = new HashSet<Bet>();
        }
        public int Id { get; set; }

        public virtual Team HomeTeam { get; set; }

        public int HomeTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public int AwayTeamId { get; set; }

        public DateTime DateTime { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
