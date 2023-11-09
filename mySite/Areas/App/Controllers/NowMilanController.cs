using Microsoft.AspNetCore.Mvc;
using mySite.Data;
using mySite.Models.Milan;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace mySite.Areas.App.Controllers
{
    [Area("App")]
    [Authorize]
    public class NowMilanController : Controller
    {

        public IActionResult Index()
        {
            var model = BuildAllInfoAboutMilanAsync();

            return View(model);
        }

        private NowMilanViewModel BuildAllInfoAboutMilanAsync()
        { 
            var milanManager = BuildGetManagerInfoAsync("Pioli", "ITA");
            var milanPlayers = BuildGetPlayersInfoAsync();
            var milanEvents = BuildGetEventAsync();
            var milanInfo = BuildGetDataAsync();

            return new NowMilanViewModel
            {
                footballManager = milanManager,
                footballPlayer = milanPlayers,
                matchEvents = milanEvents,
                milanInfo = milanInfo,
            };
        }


        /// <summary>
        /// 밀란에 관련된 정보를 가져온다.
        /// </summary>
        /// <returns></returns>
        private async Task<MilanDataRoot> BuildGetDataAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/teams/8144"),
                Headers =
                {
                    { "x-rapidapi-host", "sportscore1.p.rapidapi.com" },
                    { "x-rapidapi-key", "84c326f44dmshb5373cb36b6b085p1c8e40jsnbaf7fad7c9a8" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                var milanDataInfo = await response.Content.ReadAsStringAsync();

                MilanDataRoot milanData = JsonSerializer.Deserialize<MilanDataRoot>(milanDataInfo);

                return milanData;
            }
        }



        /// <summary>
        /// 다음경기 목록들을 가져온다.
        /// </summary>
        /// <returns></returns>
        private async Task<MatchEventsRoot> BuildGetEventAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/teams/8144/events?page=1"),
                Headers =
                {
                    { "x-rapidapi-host", "sportscore1.p.rapidapi.com" },
                    { "x-rapidapi-key", "84c326f44dmshb5373cb36b6b085p1c8e40jsnbaf7fad7c9a8" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var EventInfo = await response.Content.ReadAsStringAsync();

                MatchEventsRoot matchEvents = JsonSerializer.Deserialize<MatchEventsRoot>(EventInfo);
                return matchEvents;
            }
        }


        /// <summary>
        /// 선수들의 정보를 가져온다.
        /// </summary>
        /// <returns></returns>
        private async Task<footballPlayerRoot> BuildGetPlayersInfoAsync()
        {
            // 선수정보 불러온다.
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://sportscore1.p.rapidapi.com/teams/8144/players?page=1"),
                    Headers =
                    {
                        { "x-rapidapi-host", "sportscore1.p.rapidapi.com" },
                        { "x-rapidapi-key", "84c326f44dmshb5373cb36b6b085p1c8e40jsnbaf7fad7c9a8" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var playerInfo = await response.Content.ReadAsStringAsync();

                    footballPlayerRoot footballPlayer = JsonSerializer.Deserialize<footballPlayerRoot>(playerInfo);

                    return footballPlayer;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }
        }

        /// <summary>
        /// 감독정보를 불러온다.
        /// </summary>
        /// <param name="managerName"></param>
        /// <param name="nationality"></param>
        /// <returns></returns>
        private async Task<footballManagerRoot> BuildGetManagerInfoAsync(string managerName, string nationality)
        {
            // 감독정보를 불러온다.
            var baseUrl = "https://sportscore1.p.rapidapi.com/managers/search?page=1&name=";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(baseUrl + $"{managerName}&nationality_code={nationality}"),
                Headers =
                {
                    { "x-rapidapi-host", "sportscore1.p.rapidapi.com" },
                    { "x-rapidapi-key", "84c326f44dmshb5373cb36b6b085p1c8e40jsnbaf7fad7c9a8" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();

                    var managerInfo = await response.Content.ReadAsStringAsync();

                    footballManagerRoot getFootballManager = JsonSerializer.Deserialize<footballManagerRoot>(managerInfo);
                    return getFootballManager;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
