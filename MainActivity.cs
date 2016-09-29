using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Linq;
using System.Threading.Tasks;
using FFImageLoading;

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

            
        }

        private async Task GetCards()
        {
            //LinearLayout ll = (LinearLayout)FindViewById(Resource.Id.myLayout);
            var newLayout = new ScrollView(this);
            var myGrid = new GridLayout(this);
            myGrid.ColumnCount = 4;
            var x = await APICaller.GetCards();
            //var a = FindViewById<TextView>(Resource.Id.mylabel);
            var b = FindViewById<FFImageLoading.Views.ImageViewAsync>(Resource.Id.myimage);

            //a.Text = x.cards.FirstOrDefault().name.ToString();
            foreach (var card in x.cards)
            {
                var newImage = new FFImageLoading.Views.ImageViewAsync(this);
                ImageService.Instance.LoadUrl(card.imageUrl).Into(newImage);
                myGrid.AddView(newImage);
            }
            newLayout.AddView(myGrid);            
            SetContentView(newLayout);
        }
    }
}

