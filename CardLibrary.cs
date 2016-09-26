using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using ModernHttpClient;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PokemonTCGMaster
{
    public static class CardLibrary
    {
        public static async Task<List<DataHelper.Card>> GetCards()
        {
            string url = "https://api.pokemontcg.io/v1/cards";
            List<DataHelper.Card> x = new List<DataHelper.Card>();

            HttpClient client = new HttpClient(new NativeMessageHandler());
            var response = await client.GetAsync(url);
            if (true)
            {
                var content = await response.Content.ReadAsStringAsync();
                x = JsonConvert.DeserializeObject<List<DataHelper.Card>>(content);
            }
            return x;
        }


    }
}