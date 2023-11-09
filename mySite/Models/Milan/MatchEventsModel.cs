using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mySite.Models.Milan
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class TimeDetails
    {
        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("initial")]
        public int Initial { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("extra")]
        public int Extra { get; set; }
    }

    public class NameTranslations5
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

    public class HomeTeam
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
        public NameTranslations5 NameTranslations { get; set; }

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

    public class AwayTeam
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
        public NameTranslations5 NameTranslations { get; set; }

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

    public class HomeScore
    {
        [JsonPropertyName("current")]
        public int Current { get; set; }

        [JsonPropertyName("display")]
        public int Display { get; set; }

        [JsonPropertyName("period_1")]
        public int Period1 { get; set; }

        [JsonPropertyName("normal_time")]
        public int NormalTime { get; set; }

        [JsonPropertyName("over_time")]
        public int? OverTime { get; set; }

        [JsonPropertyName("period_2")]
        public int? Period2 { get; set; }

        [JsonPropertyName("penalties")]
        public int? Penalties { get; set; }
    }

    public class AwayScore
    {
        [JsonPropertyName("current")]
        public int Current { get; set; }

        [JsonPropertyName("display")]
        public int Display { get; set; }

        [JsonPropertyName("period_1")]
        public int Period1 { get; set; }

        [JsonPropertyName("normal_time")]
        public int NormalTime { get; set; }

        [JsonPropertyName("over_time")]
        public int? OverTime { get; set; }

        [JsonPropertyName("period_2")]
        public int? Period2 { get; set; }

        [JsonPropertyName("penalties")]
        public int? Penalties { get; set; }
    }

    public class RoundInfo
    {
        [JsonPropertyName("round")]
        public int Round { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("cupRoundType")]
        public int? CupRoundType { get; set; }
    }

    public class BallPossession
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class TotalShots
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class ShotsOnTarget
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class ShotsOffTarget
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class BlockedShots
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class CornerKicks
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class Offsides
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class Fouls
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class YellowCards
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class BigChances
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class BigChancesMissed
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class ShotsInsideBox
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class ShotsOutsideBox
    {
        [JsonPropertyName("home")]
        public int Home { get; set; }

        [JsonPropertyName("away")]
        public int Away { get; set; }
    }

    public class MainStat
    {
        [JsonPropertyName("ball_possession")]
        public BallPossession BallPossession { get; set; }

        [JsonPropertyName("total_shots")]
        public TotalShots TotalShots { get; set; }

        [JsonPropertyName("shots_on_target")]
        public ShotsOnTarget ShotsOnTarget { get; set; }

        [JsonPropertyName("shots_off_target")]
        public ShotsOffTarget ShotsOffTarget { get; set; }

        [JsonPropertyName("blocked_shots")]
        public BlockedShots BlockedShots { get; set; }

        [JsonPropertyName("corner_kicks")]
        public CornerKicks CornerKicks { get; set; }

        [JsonPropertyName("offsides")]
        public Offsides Offsides { get; set; }

        [JsonPropertyName("fouls")]
        public Fouls Fouls { get; set; }

        [JsonPropertyName("yellow_cards")]
        public YellowCards YellowCards { get; set; }

        [JsonPropertyName("big_chances")]
        public BigChances BigChances { get; set; }

        [JsonPropertyName("big_chances_missed")]
        public BigChancesMissed BigChancesMissed { get; set; }

        [JsonPropertyName("shots_inside_box")]
        public ShotsInsideBox ShotsInsideBox { get; set; }

        [JsonPropertyName("shots_outside_box")]
        public ShotsOutsideBox ShotsOutsideBox { get; set; }
    }

    public class Outcome1
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("change")]
        public int Change { get; set; }
    }

    public class OutcomeX
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("change")]
        public int Change { get; set; }
    }

    public class Outcome2
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("change")]
        public int Change { get; set; }
    }

    public class MainOdds
    {
        [JsonPropertyName("outcome_1")]
        public Outcome1 Outcome1 { get; set; }

        [JsonPropertyName("outcome_X")]
        public OutcomeX OutcomeX { get; set; }

        [JsonPropertyName("outcome_2")]
        public Outcome2 Outcome2 { get; set; }
    }

    public class League
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sport_id")]
        public int SportId { get; set; }

        [JsonPropertyName("section_id")]
        public int SectionId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_translations")]
        public NameTranslations5 NameTranslations { get; set; }

        [JsonPropertyName("has_logo")]
        public bool HasLogo { get; set; }

        [JsonPropertyName("logo")]
        public string Logo { get; set; }
    }

    public class Challenge
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sport_id")]
        public int SportId { get; set; }

        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_translations")]
        public NameTranslations5 NameTranslations { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }
    }

    public class Season
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("year_start")]
        public int YearStart { get; set; }

        [JsonPropertyName("year_end")]
        public int? YearEnd { get; set; }
    }

    public class Section
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sport_id")]
        public int SportId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("flag")]
        public string Flag { get; set; }
    }

    public class Sport
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class MatchEvents
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sport_id")]
        public int SportId { get; set; }

        [JsonPropertyName("home_team_id")]
        public int HomeTeamId { get; set; }

        [JsonPropertyName("away_team_id")]
        public int AwayTeamId { get; set; }

        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("challenge_id")]
        public int ChallengeId { get; set; }

        [JsonPropertyName("season_id")]
        public int? SeasonId { get; set; }

        [JsonPropertyName("venue_id")]
        public int? VenueId { get; set; }

        [JsonPropertyName("referee_id")]
        public int? RefereeId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("status_more")]
        public string StatusMore { get; set; }

        [JsonPropertyName("time_details")]
        public TimeDetails TimeDetails { get; set; }

        [JsonPropertyName("home_team")]
        public HomeTeam HomeTeam { get; set; }

        [JsonPropertyName("away_team")]
        public AwayTeam AwayTeam { get; set; }

        [JsonPropertyName("start_at")]
        public string StartAt { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("home_score")]
        public HomeScore HomeScore { get; set; }

        [JsonPropertyName("away_score")]
        public AwayScore AwayScore { get; set; }

        [JsonPropertyName("winner_code")]
        public int? WinnerCode { get; set; }

        [JsonPropertyName("aggregated_winner_code")]
        public object AggregatedWinnerCode { get; set; }

        [JsonPropertyName("result_only")]
        public bool ResultOnly { get; set; }

        [JsonPropertyName("coverage")]
        public int? Coverage { get; set; }

        [JsonPropertyName("ground_type")]
        public object GroundType { get; set; }

        [JsonPropertyName("round_number")]
        public int? RoundNumber { get; set; }

        [JsonPropertyName("series_count")]
        public int? SeriesCount { get; set; }

        [JsonPropertyName("medias_count")]
        public int? MediasCount { get; set; }

        [JsonPropertyName("status_lineup")]
        public int? StatusLineup { get; set; }

        [JsonPropertyName("first_supply")]
        public object FirstSupply { get; set; }

        [JsonPropertyName("cards_code")]
        public string CardsCode { get; set; }

        [JsonPropertyName("event_data_change")]
        public string EventDataChange { get; set; }

        [JsonPropertyName("lasted_period")]
        public string LastedPeriod { get; set; }

        [JsonPropertyName("default_period_count")]
        public int? DefaultPeriodCount { get; set; }

        [JsonPropertyName("attendance")]
        public int? Attendance { get; set; }

        [JsonPropertyName("cup_match_order")]
        public int? CupMatchOrder { get; set; }

        [JsonPropertyName("cup_match_in_round")]
        public int? CupMatchInRound { get; set; }

        [JsonPropertyName("periods")]
        public object Periods { get; set; }

        [JsonPropertyName("round_info")]
        public RoundInfo RoundInfo { get; set; }

        [JsonPropertyName("periods_time")]
        public object PeriodsTime { get; set; }

        [JsonPropertyName("main_stat")]
        public MainStat MainStat { get; set; }

        [JsonPropertyName("main_odds")]
        public MainOdds MainOdds { get; set; }

        [JsonPropertyName("league")]
        public League League { get; set; }

        [JsonPropertyName("challenge")]
        public Challenge Challenge { get; set; }

        [JsonPropertyName("season")]
        public Season Season { get; set; }

        [JsonPropertyName("section")]
        public Section Section { get; set; }

        [JsonPropertyName("sport")]
        public Sport Sport { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }
    }

    public class MatchEventsRoot
    {
        [JsonPropertyName("data")]
        public List<MatchEvents> matchEvents { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }


}
