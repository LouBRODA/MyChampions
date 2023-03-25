using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Data;
using System.Net.Http.Json;

//Class Champion Manager Used to Link MAUI Solution with API

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

        //Get
        public async Task<List<Champion>> GetAllChampions()
        {
            var champions = await _httpClient.GetFromJsonAsync<List<Champion>>("/api/champions");
            return champions;
        }

        //GetByName
        public async Task<Champion> GetChampionByName(string name)
        {
            var champion = await _httpClient.GetFromJsonAsync<Champion>($"/api/champions/{name}");
            return champion;
        }

        //Add
        public async Task<Champion> AddChampion(Champion champion)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/champions", champion);
            response.EnsureSuccessStatusCode();
            var newChampion = await response.Content.ReadFromJsonAsync<Champion>();
            return newChampion;
        }

        //Update
        public async Task UpdateChampion(string name, Champion champion)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/champions/{name}", champion);
            response.EnsureSuccessStatusCode();
        }

        //Delete
        public async Task DeleteChampion(string name)
        {
            var response = await _httpClient.DeleteAsync($"/api/champions/{name}");
            response.EnsureSuccessStatusCode();
        }

    }
}
