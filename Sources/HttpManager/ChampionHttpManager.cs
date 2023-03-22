using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Http.Json;

namespace API_MyChampions.Client
{
    public class ChampionHttpManager
    {
        private readonly HttpClient _httpClient;

        public ChampionHttpManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri("http://localhost:5010");
        }

        public async Task<IActionResult> GetChampion()
        {
            var champions = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDTO>>("api/");
            return (IActionResult)champions;
        }
 
    }
}
