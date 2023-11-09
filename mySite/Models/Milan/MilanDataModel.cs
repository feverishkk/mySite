using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mySite.Models.Milan
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class NameTranslations4
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

    public class Sport2
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_translations")]
        public NameTranslations4 NameTranslations { get; set; }
    }

    public class Section2
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sport_id")]
        public int SportId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_translations")]
        public NameTranslations4 NameTranslations { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("flag")]
        public string Flag { get; set; }
    }

    public class City
    {
        [JsonPropertyName("en")]
        public string En { get; set; }
    }

    public class Stadium
    {
        [JsonPropertyName("en")]
        public string En { get; set; }
    }

    public class Venue
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("city")]
        public City City { get; set; }

        [JsonPropertyName("stadium")]
        public Stadium Stadium { get; set; }

        [JsonPropertyName("stadium_capacity")]
        public int StadiumCapacity { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("country_flag")]
        public string CountryFlag { get; set; }
    }

    public class Performance2
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("draws")]
        public int Draws { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("goals_scored")]
        public int GoalsScored { get; set; }

        [JsonPropertyName("goals_conceded")]
        public int GoalsConceded { get; set; }

        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }
    }

    public class Manager
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sport_id")]
        public int SportId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_translations")]
        public NameTranslations4 NameTranslations { get; set; }

        [JsonPropertyName("name_short")]
        public string NameShort { get; set; }

        [JsonPropertyName("has_photo")]
        public bool HasPhoto { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("date_birth")]
        public object DateBirth { get; set; }

        [JsonPropertyName("nationality_code")]
        public string NationalityCode { get; set; }

        [JsonPropertyName("performance")]
        public Performance Performance { get; set; }

        [JsonPropertyName("preferred_formation")]
        public string PreferredFormation { get; set; }
    }

    public class MilanData
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
        public NameTranslations4 NameTranslations { get; set; }

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

        [JsonPropertyName("details")]
        public object Details { get; set; }

        [JsonPropertyName("sport")]
        public Sport Sport { get; set; }

        [JsonPropertyName("section")]
        public Section Section { get; set; }

        [JsonPropertyName("venue")]
        public Venue Venue { get; set; }

        [JsonPropertyName("manager")]
        public Manager Manager { get; set; }

        [JsonPropertyName("tennis_ranking")]
        public object TennisRanking { get; set; }
    }

    public class MilanDataRoot
    {
        [JsonPropertyName("data")]
        public MilanData milanData { get; set; }

        [JsonPropertyName("meta")]
        public object Meta { get; set; }
    }

}
