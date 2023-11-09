using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mySite.Models.Milan
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class NameTranslations3
    {
        [JsonPropertyName("en")]
        public string En { get; set; }
    }

    public class Positive
    {
        [JsonPropertyName("feature")]
        public string Feature { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

    public class Negative
    {
        [JsonPropertyName("feature")]
        public string Feature { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

    public class Characteristics
    {
        [JsonPropertyName("positive")]
        public List<Positive> Positive { get; set; }

        [JsonPropertyName("negative")]
        public List<Negative> Negative { get; set; }
    }

    public class Positions
    {
        [JsonPropertyName("main")]
        public object Main { get; set; }
    }

    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("full_average")]
        public int FullAverage { get; set; }
    }

    public class footballPlayer
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
        public NameTranslations3 NameTranslations { get; set; }

        [JsonPropertyName("name_short")]
        public string NameShort { get; set; }

        [JsonPropertyName("has_photo")]
        public bool HasPhoto { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("position_name")]
        public string PositionName { get; set; }

        [JsonPropertyName("weight")]
        public int? Weight { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("date_birth_at")]
        public string DateBirthAt { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("shirt_number")]
        public int? ShirtNumber { get; set; }

        [JsonPropertyName("preferred_foot")]
        public string PreferredFoot { get; set; }

        [JsonPropertyName("nationality_code")]
        public string NationalityCode { get; set; }

        [JsonPropertyName("flag")]
        public string Flag { get; set; }

        [JsonPropertyName("market_currency")]
        public string MarketCurrency { get; set; }

        [JsonPropertyName("market_value")]
        public int? MarketValue { get; set; }

        [JsonPropertyName("contract_until")]
        public string ContractUntil { get; set; }

        [JsonPropertyName("rating")]
        public double? Rating { get; set; }

        [JsonPropertyName("characteristics")]
        public Characteristics Characteristics { get; set; }

        [JsonPropertyName("positions")]
        public Positions Positions { get; set; }

        [JsonPropertyName("ability")]
        public List<Ability> Ability { get; set; }
    }

    public class Meta3
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

    public class footballPlayerRoot
    {
        [JsonPropertyName("data")]
        public List<footballPlayer> Players { get; set; }

        [JsonPropertyName("meta")]
        public Meta3 Meta { get; set; }
    }


}
