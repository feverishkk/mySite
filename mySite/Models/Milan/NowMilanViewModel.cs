using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Models.Milan
{
    public class NowMilanViewModel
    {

        public Task<footballManagerRoot> footballManager { get; set; }

        public Task<MatchEventsRoot> matchEvents { get; set; }

        public Task<footballPlayerRoot> footballPlayer { get; set; }

        public Task<MilanDataRoot> milanInfo { get; set; }

        public Task<LeagueStandingRoot> leagueStanding { get; set; }

        //public Task<LeagueStandingRoot> leagueStanding { get; set; }

    }
}
