using DeviceTest.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace DeviceTest.Services
{
    internal class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthService.Token);
        }
    
        public async Task<List<Item>> GetItemsAsync()
        {
            return await _client.GetFromJsonAsync<List<Item>>(
                "https://yourapi.com/api/items");
        }
    }
}
