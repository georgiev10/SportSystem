namespace SportSystem.Data
{
    using System.Data.Entity;

    using SportSystem.Models;

    public interface ISportSystemDbContext
    {
        IDbSet<Team> Teams { get; set; }

        IDbSet<Player> Players { get; set; }

        IDbSet<Match> Matches { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Bet> Bets { get; set; }

        IDbSet<Vote> Votes { get; set; }

        int SaveChanges();
    }
}
