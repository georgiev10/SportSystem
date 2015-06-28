using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportSystem.Models;
using System.Data.Entity;
using SportSystem.Data.Migrations;

namespace SportSystem.Data
{
    public class SportSystemDbContext : IdentityDbContext<User>, ISportSystemDbContext
    {
        public SportSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportSystemDbContext, Configuration>());
        }

        public static SportSystemDbContext Create()
        {
            return new SportSystemDbContext();
        }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Vote> Votes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Vote>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Votes)
                .WillCascadeOnDelete(false);

            modelBuilder
               .Entity<Comment>()
               .HasRequired(x => x.User)
               .WithMany(x => x.Comments)
               .WillCascadeOnDelete(false);

            modelBuilder
               .Entity<Match>()
               .HasRequired(x => x.HomeTeam)
               .WithMany(x => x.Matches)
               .WillCascadeOnDelete(false);

            //modelBuilder
            //  .Entity<Match>()
            //  .HasRequired(x => x.AwayTeam)
            //  .WithMany(x => x.Matches)
            //  .WillCascadeOnDelete(false);

            modelBuilder
               .Entity<Bet>()
               .HasRequired(x => x.User)
               .WithMany(x => x.Bets)
               .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }




    }
}
