namespace SportSystem.Data
{
    using SportSystem.Data.Repositories;
    using SportSystem.Models;

    public interface ISportSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Player> Players { get; }

        IRepository<Team> Teams { get; }

        IRepository<Match> Matches { get; }

        IRepository<Bet> Bets { get; }

        int SaveChanges();
    }
}
