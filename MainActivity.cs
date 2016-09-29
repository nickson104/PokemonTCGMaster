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
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            base.OnCreate(bundle);
            var SearchCard = FindViewById<Button>(Resource.Id.SearchCard);
            SearchCard.Click += (o,e) => { SearchCards(); };
            var getcards = FindViewById<Button>(Resource.Id.GetCards);
            getcards.Click += (o, e) => { GetCards(); };
            //GetCards();      
        }

        protected void SearchCards()
        {
            string searchCriteria = FindViewById<EditText>(Resource.Id.mytextbox).Text;
            SearchCards(searchCriteria);
        }

        protected void GetCards()
        {
            GetCardsAsync();
        }

        private async Task GetCardsAsync()
        {
            var newLayout = new ScrollView(this);
            var myGrid = new GridLayout(this);
            myGrid.ColumnCount = 4;
            var x = await APICaller.GetCards();
            //a.Text = x.cards.FirstOrDefault().name.ToString();
            foreach (var card in x.cards)
            {
                var newImage = new FFImageLoading.Views.ImageViewAsync(this);
                ImageService.Instance.LoadUrl(card.imageUrl).DownSample(width: 150).Into(newImage);
                myGrid.AddView(newImage);
            }
            newLayout.AddView(myGrid);            
            SetContentView(newLayout);
        }
        private async Task SearchCards(string param)
        {
            var newLayout = new ScrollView(this);
            var myGrid = new GridLayout(this);
            myGrid.ColumnCount = 4;
            var x = await APICaller.SearchCards(param);
            //a.Text = x.cards.FirstOrDefault().name.ToString();
            foreach (var card in x.cards)
            {
                var newImage = new FFImageLoading.Views.ImageViewAsync(this);
                ImageService.Instance.LoadUrl(card.imageUrl).DownSample(width: 150).Into(newImage);
                myGrid.AddView(newImage);
            }
            newLayout.AddView(myGrid);
            SetContentView(newLayout);
        }
    }
}

