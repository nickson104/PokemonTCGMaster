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
using SQLite;

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

            CreateDatabase();

            base.OnCreate(bundle);
            var SearchCard = FindViewById<Button>(Resource.Id.SearchCard);
            SearchCard.Click += (o, e) => { SearchCards(); };
            var getcards = FindViewById<Button>(Resource.Id.GetCards);
            getcards.Click += (o, e) => { GetCards(); };
            //GetCards();      
        }

        private static void CreateDatabase()
        {
            try
            {
                var db = new SQLiteConnection(DataHelper.databasePath);
                db.CreateTable<DataHelper.myCards.Card>();
                //db.CreateTable<DataHelper.Sets.Set>();
                //db.CreateTable<DataHelper.myCards.Attack>();
                //db.CreateTable<DataHelper.myCards.Weakness>();
                //db.CreateTable<DataHelper.myCards.Resistance>();
                //db.CreateTable<DataHelper.myCards.Ability>();
                //db.CreateTable<DataHelper.CardTypes>();
                //db.CreateTable<DataHelper.PokemonTypes>();
                //db.CreateTable<DataHelper.Series>();
                //db.CreateTable<DataHelper.Deck>();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected void SearchCards()
        {
            string searchCriteria = FindViewById<EditText>(Resource.Id.mytextbox).Text;
            SearchCards(searchCriteria);
        }

        protected async void GetCards()
        {
            await GetCardsAsync();
            await GetCardsFromDB();
        }

        private async Task GetCardsFromDB()
        {
            var newLayout = new ScrollView(this);
            var myGrid = new GridLayout(this);
            myGrid.ColumnCount = 4;

            var db = new SQLiteConnection(DataHelper.databasePath);
            var myCards = db.Table<DataHelper.myCards.Card>().ToList();

            foreach (var card in myCards)
            {
                var newImage = new FFImageLoading.Views.ImageViewAsync(this);
                ImageService.Instance.LoadUrl(card.imageUrl).DownSample(width: 150).Into(newImage);
                myGrid.AddView(newImage);
            }
            newLayout.AddView(myGrid);
            SetContentView(newLayout);
        }

        private async Task GetCardsAsync()
        {
            var x = await APICaller.GetCards();
            //a.Text = x.cards.FirstOrDefault().name.ToString();
            foreach (var card in x.cards)
            {
                InsertIntoDatabase(card);      
            }
        }



        private void InsertIntoDatabase(DataHelper.apiCards.Card card)
        {
            var db = new SQLiteConnection(DataHelper.databasePath);
            if (!db.Table<DataHelper.myCards.Card>().Any(c=>c.set == card.set && c.number == card.number))
            {
                DataHelper.myCards.Card myCard = new DataHelper.myCards.Card
                {
                    artist = card.artist,
                    hp = card.hp,
                    imageUrl = card.imageUrl,
                    name = card.name,
                    nationalPokedexNumber = card.nationalPokedexNumber,
                    number = card.number,
                    rarity = card.rarity,
                    //retreatCost = card.retreatCost,
                    series = card.series,
                    set = card.set,
                    setCode = card.setCode,
                    //subtype = card.subtype,
                    //supertype = card.supertype,
                    text = CommonMethods.StringListToString(card.text)
            };
                db.Insert(myCard);
            }
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

