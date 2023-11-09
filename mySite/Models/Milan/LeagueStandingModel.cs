using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mySite.Models.Milan
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class TotalKeys
    {
        [JsonPropertyName("matches_total")]
        public string MatchesTotal { get; set; }

        [JsonPropertyName("wins_total")]
        public string WinsTotal { get; set; }

        [JsonPropertyName("draws_total")]
        public string DrawsTotal { get; set; }

        [JsonPropertyName("losses_total")]
        public string LossesTotal { get; set; }

        [JsonPropertyName("goals_total")]
        public string GoalsTotal { get; set; }

        [JsonPropertyName("points_total")]
        public string PointsTotal { get; set; }
    }

    public class HomeKeys
    {
        [JsonPropertyName("matches_home")]
        public string MatchesHome { get; set; }

        [JsonPropertyName("wins_home")]
        public string WinsHome { get; set; }

        [JsonPropertyName("draws_home")]
        public string DrawsHome { get; set; }

        [JsonPropertyName("losses_home")]
        public string LossesHome { get; set; }

        [JsonPropertyName("goals_home")]
        public string GoalsHome { get; set; }

        [JsonPropertyName("points_home")]
        public string PointsHome { get; set; }
    }

    public class AwayKeys
    {
        [JsonPropertyName("matches_away")]
        public string MatchesAway { get; set; }

        [JsonPropertyName("wins_away")]
        public string WinsAway { get; set; }

        [JsonPropertyName("draws_away")]
        public string DrawsAway { get; set; }

        [JsonPropertyName("losses_away")]
        public string LossesAway { get; set; }

        [JsonPropertyName("goals_away")]
        public string GoalsAway { get; set; }

        [JsonPropertyName("points_away")]
        public string PointsAway { get; set; }
    }

    public class Fields
    {
        [JsonPropertyName("matches_total")]
        public string MatchesTotal { get; set; }

        [JsonPropertyName("wins_total")]
        public string WinsTotal { get; set; }

        [JsonPropertyName("draws_total")]
        public string DrawsTotal { get; set; }

        [JsonPropertyName("losses_total")]
        public string LossesTotal { get; set; }

        [JsonPropertyName("wins_losses_total")]
        public string WinsLossesTotal { get; set; }

        [JsonPropertyName("goals_total")]
        public string GoalsTotal { get; set; }

        [JsonPropertyName("pct_goal_total")]
        public string PctGoalTotal { get; set; }

        [JsonPropertyName("score_diff_formatted_total")]
        public string ScoreDiffFormattedTotal { get; set; }

        [JsonPropertyName("points_total")]
        public string PointsTotal { get; set; }

        [JsonPropertyName("percentage_total")]
        public string PercentageTotal { get; set; }

        [JsonPropertyName("games_behind_total")]
        public string GamesBehindTotal { get; set; }

        [JsonPropertyName("overtime_wins_total")]
        public string OvertimeWinsTotal { get; set; }

        [JsonPropertyName("overtime_losses_total")]
        public string OvertimeLossesTotal { get; set; }

        [JsonPropertyName("penalty_wins_total")]
        public string PenaltyWinsTotal { get; set; }

        [JsonPropertyName("penalty_losses_total")]
        public string PenaltyLossesTotal { get; set; }

        [JsonPropertyName("overtime_and_penalty_wins_total")]
        public string OvertimeAndPenaltyWinsTotal { get; set; }

        [JsonPropertyName("three_points_total")]
        public string ThreePointsTotal { get; set; }

        [JsonPropertyName("two_points_total")]
        public string TwoPointsTotal { get; set; }

        [JsonPropertyName("one_point_total")]
        public string OnePointTotal { get; set; }

        [JsonPropertyName("no_result_total")]
        public string NoResultTotal { get; set; }

        [JsonPropertyName("net_run_rate_total")]
        public string NetRunRateTotal { get; set; }

        [JsonPropertyName("streak_total")]
        public string StreakTotal { get; set; }
    }

    public class HomeFields
    {
        [JsonPropertyName("matches_home")]
        public string MatchesHome { get; set; }

        [JsonPropertyName("wins_home")]
        public string WinsHome { get; set; }

        [JsonPropertyName("draws_home")]
        public string DrawsHome { get; set; }

        [JsonPropertyName("losses_home")]
        public string LossesHome { get; set; }

        [JsonPropertyName("wins_losses_home")]
        public string WinsLossesHome { get; set; }

        [JsonPropertyName("goals_home")]
        public string GoalsHome { get; set; }

        [JsonPropertyName("pct_goal_home")]
        public string PctGoalHome { get; set; }

        [JsonPropertyName("score_diff_formatted_home")]
        public string ScoreDiffFormattedHome { get; set; }

        [JsonPropertyName("points_home")]
        public string PointsHome { get; set; }

        [JsonPropertyName("percentage_home")]
        public string PercentageHome { get; set; }

        [JsonPropertyName("games_behind_home")]
        public string GamesBehindHome { get; set; }

        [JsonPropertyName("overtime_wins_home")]
        public string OvertimeWinsHome { get; set; }

        [JsonPropertyName("overtime_losses_home")]
        public string OvertimeLossesHome { get; set; }

        [JsonPropertyName("penalty_wins_home")]
        public string PenaltyWinsHome { get; set; }

        [JsonPropertyName("penalty_losses_home")]
        public string PenaltyLossesHome { get; set; }

        [JsonPropertyName("overtime_and_penalty_wins_home")]
        public string OvertimeAndPenaltyWinsHome { get; set; }

        [JsonPropertyName("three_points_home")]
        public string ThreePointsHome { get; set; }

        [JsonPropertyName("two_points_home")]
        public string TwoPointsHome { get; set; }

        [JsonPropertyName("one_point_home")]
        public string OnePointHome { get; set; }

        [JsonPropertyName("no_result_home")]
        public string NoResultHome { get; set; }

        [JsonPropertyName("net_run_rate_home")]
        public string NetRunRateHome { get; set; }

        [JsonPropertyName("streak_home")]
        public string StreakHome { get; set; }
    }

    public class AwayFields
    {
        [JsonPropertyName("matches_away")]
        public string MatchesAway { get; set; }

        [JsonPropertyName("wins_away")]
        public string WinsAway { get; set; }

        [JsonPropertyName("draws_away")]
        public string DrawsAway { get; set; }

        [JsonPropertyName("losses_away")]
        public string LossesAway { get; set; }

        [JsonPropertyName("wins_losses_away")]
        public string WinsLossesAway { get; set; }

        [JsonPropertyName("goals_away")]
        public string GoalsAway { get; set; }

        [JsonPropertyName("pct_goal_away")]
        public string PctGoalAway { get; set; }

        [JsonPropertyName("score_diff_formatted_away")]
        public string ScoreDiffFormattedAway { get; set; }

        [JsonPropertyName("points_away")]
        public string PointsAway { get; set; }

        [JsonPropertyName("percentage_away")]
        public string PercentageAway { get; set; }

        [JsonPropertyName("games_behind_away")]
        public string GamesBehindAway { get; set; }

        [JsonPropertyName("overtime_wins_away")]
        public string OvertimeWinsAway { get; set; }

        [JsonPropertyName("overtime_losses_away")]
        public string OvertimeLossesAway { get; set; }

        [JsonPropertyName("penalty_wins_away")]
        public string PenaltyWinsAway { get; set; }

        [JsonPropertyName("penalty_losses_away")]
        public string PenaltyLossesAway { get; set; }

        [JsonPropertyName("overtime_and_penalty_wins_away")]
        public string OvertimeAndPenaltyWinsAway { get; set; }

        [JsonPropertyName("three_points_away")]
        public string ThreePointsAway { get; set; }

        [JsonPropertyName("two_points_away")]
        public string TwoPointsAway { get; set; }

        [JsonPropertyName("one_point_away")]
        public string OnePointAway { get; set; }

        [JsonPropertyName("no_result_away")]
        public string NoResultAway { get; set; }

        [JsonPropertyName("net_run_rate_away")]
        public string NetRunRateAway { get; set; }

        [JsonPropertyName("streak_away")]
        public string StreakAway { get; set; }
    }

    public class Details
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class NameTranslations6
    {
        [JsonPropertyName("en")]
        public string En { get; set; }

        [JsonPropertyName("ru")]
        public string Ru { get; set; }

        [JsonPropertyName("de")]
        public string De { get; set; }

        [JsonPropertyName("es")]
        public string Es { get; set; }

        [JsonPropertyName("fr")]
        public string Fr { get; set; }

        [JsonPropertyName("zh")]
        public string Zh { get; set; }

        [JsonPropertyName("tr")]
        public string Tr { get; set; }

        [JsonPropertyName("el")]
        public string El { get; set; }

        [JsonPropertyName("it")]
        public string It { get; set; }

        [JsonPropertyName("nl")]
        public string Nl { get; set; }

        [JsonPropertyName("pt")]
        public string Pt { get; set; }
    }

    public class Team
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sport_id")]
        public int SportId { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("venue_id")]
        public int VenueId { get; set; }

        [JsonPropertyName("manager_id")]
        public int ManagerId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("has_logo")]
        public bool HasLogo { get; set; }

        [JsonPropertyName("logo")]
        public string Logo { get; set; }

        [JsonPropertyName("name_translations")]
        public NameTranslations6 NameTranslations { get; set; }

        [JsonPropertyName("name_short")]
        public string NameShort { get; set; }

        [JsonPropertyName("name_full")]
        public string NameFull { get; set; }

        [JsonPropertyName("name_code")]
        public string NameCode { get; set; }

        [JsonPropertyName("has_sub")]
        public bool HasSub { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("is_nationality")]
        public bool IsNationality { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("flag")]
        public string Flag { get; set; }

        [JsonPropertyName("foundation")]
        public object Foundation { get; set; }
    }

    public class StandingsRow
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("home_position")]
        public int HomePosition { get; set; }

        [JsonPropertyName("away_position")]
        public int AwayPosition { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("home_points")]
        public string HomePoints { get; set; }

        [JsonPropertyName("away_points")]
        public string AwayPoints { get; set; }

        [JsonPropertyName("fields")]
        public Fields Fields { get; set; }

        [JsonPropertyName("home_fields")]
        public HomeFields HomeFields { get; set; }

        [JsonPropertyName("away_fields")]
        public AwayFields AwayFields { get; set; }

        [JsonPropertyName("details")]
        public Details Details { get; set; }

        [JsonPropertyName("team")]
        public Team Team { get; set; }
    }

    public class LeagueStanding
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("round")]
        public int Round { get; set; }

        [JsonPropertyName("total_keys")]
        public TotalKeys TotalKeys { get; set; }

        [JsonPropertyName("home_keys")]
        public HomeKeys HomeKeys { get; set; }

        [JsonPropertyName("away_keys")]
        public AwayKeys AwayKeys { get; set; }

        [JsonPropertyName("standings_rows")]
        public List<StandingsRow> StandingsRows { get; set; }
    }

    public class LeagueStandingRoot
    {
        [JsonPropertyName("data")]
        public List<LeagueStanding> leagueStandings { get; set; }

        [JsonPropertyName("meta")]
        public object Meta { get; set; }
    }


}
