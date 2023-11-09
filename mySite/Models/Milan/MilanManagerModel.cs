using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mySite.Models.Milan
{
    // From json2csharp.com
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class NameTranslations1
    {
        [JsonPropertyName("en")]
        public string En { get; set; }
    }

    public class Performance
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

    public class MilanManagerModel
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
        public NameTranslations1 NameTranslations { get; set; }

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

    public class Meta1
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

    public class footballManagerRoot
    {
        [JsonPropertyName("data")]
        public List<MilanManagerModel> Manager { get; set; }

        [JsonPropertyName("meta")]
        public Meta1 Meta { get; set; }

        public static implicit operator Task<object>(footballManagerRoot v)
        {
            throw new NotImplementedException();
        }
    }
}
