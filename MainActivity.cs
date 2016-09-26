using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTCGMaster
{
    [Activity(Label = "PokemonTCGMaster", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            GetCards();
            // Get our button from the layout resource,
            // and attach an event to it
            
        }

        private async Task GetCards()
        {
            var x = await CardLibrary.GetCards();

            var a = FindViewById<TextView>(Resource.Id.mylabel);

            a.Text = x.FirstOrDefault().ToString();
        }
    }
}

