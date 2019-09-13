using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using RandomWord.Models;
using System.Diagnostics;

namespace RandomWord.Services
{
    public class WordDataStore
    {
        HttpClient client;
        Item items;

        public WordDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"https://somsak.herokuapp.com");
            items = new Item();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<Item> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"/items.json");
                items = await Task.Run(() => JsonConvert.DeserializeObject<Item>(json));
            }
            return items;
        }

    }
}
