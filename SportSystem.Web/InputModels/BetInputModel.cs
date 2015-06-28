using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.InputModels
{
    public class BetInputModel:IMapTo<Bet>
    {
        public int MatchId { get; set; }

        public decimal HomeBet { get; set; }
       
        public decimal AwayBet { get; set; }
      
        public string UserId { get; set; }
    }
}