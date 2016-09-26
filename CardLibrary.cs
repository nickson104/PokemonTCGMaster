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
        public static async Task<DataHelper.RootObject> GetCards()
        {
            string url = "https://api.pokemontcg.io/v1/cards";
            DataHelper.RootObject x = new DataHelper.RootObject();

            HttpClient client = new HttpClient(new NativeMessageHandler());
            var response = await client.GetAsync(url).ConfigureAwait(false); ;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;
                string jsonString = await content.ReadAsStringAsync().ConfigureAwait(false);
                x = JsonConvert.DeserializeObject<DataHelper.RootObject>(jsonString);
            }
            return x;
        }


    }
}