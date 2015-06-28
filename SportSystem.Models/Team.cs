using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Media;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SportSystem.Models
{
    public class Team
    {
        public Team()
        {
            this.Players=new HashSet<Player>();
            this.Matches=new HashSet<Match>();
            this.Votes = new HashSet<Vote>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string NickName { get; set; }

        public string WebSite { get; set; }

        public DateTime? DateFounded { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
