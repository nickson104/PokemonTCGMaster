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
    public static class APICaller
    {
        public static async Task<DataHelper.cards.RootObject> GetCards()
        {
            string url = "https://api.pokemontcg.io/v1/cards?";
            url += "series=" + DataHelper.Series.XY;
            url += "&pageSize=200";
            // page=2 
            DataHelper.cards.RootObject cards = new DataHelper.cards.RootObject();

            HttpClient client = new HttpClient(new NativeMessageHandler());
            var response = await client.GetAsync(url).ConfigureAwait(false); ;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;
                string jsonString = await content.ReadAsStringAsync().ConfigureAwait(false);
                cards = JsonConvert.DeserializeObject<DataHelper.cards.RootObject>(jsonString);
            }
            return cards;
        }

        public static async Task<DataHelper.cards.RootObject> SearchCards(string param)
        {
            string url = "https://api.pokemontcg.io/v1/cards?";
            url += "name=" + param;
            url += "&pageSize=200";
            // page=2 
            DataHelper.cards.RootObject cards = new DataHelper.cards.RootObject();

            HttpClient client = new HttpClient(new NativeMessageHandler());
            var response = await client.GetAsync(url).ConfigureAwait(false); ;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;
                string jsonString = await content.ReadAsStringAsync().ConfigureAwait(false);
                cards = JsonConvert.DeserializeObject<DataHelper.cards.RootObject>(jsonString);
            }
            return cards;
        }
    }

    public static class CardLibrary
    {

    }
}