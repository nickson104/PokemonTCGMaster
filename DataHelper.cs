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

namespace PokemonTCGMaster
{
    public class DataHelper
    {
        public class cards
        {
            public class Card
            {
                public string id { get; set; }
                public string name { get; set; }
                public int nationalPokedexNumber { get; set; }
                public string imageUrl { get; set; }
                public string subtype { get; set; }
                public string supertype { get; set; }
                public string hp { get; set; }
                public List<string> retreatCost { get; set; }
                public string number { get; set; }
                public string artist { get; set; }
                public string rarity { get; set; }
                public string series { get; set; }
                public string set { get; set; }
                public string setCode { get; set; }
                public List<string> types { get; set; }
                public List<Attack> attacks { get; set; }
                public List<Weakness> weaknesses { get; set; }
                public Ability ability { get; set; }
                public List<string> text { get; set; }
                public List<Resistance> resistances { get; set; }
            }

            public class Attack
            {
                public List<string> cost { get; set; }
                public string name { get; set; }
                public string text { get; set; }
                public string damage { get; set; }
                public int convertedEnergyCost { get; set; }
            }

            public class Weakness
            {
                public string type { get; set; }
                public string value { get; set; }
            }

            public class Ability
            {
                public string name { get; set; }
                public string text { get; set; }
            }

            public class Resistance
            {
                public string type { get; set; }
                public string value { get; set; }
            }

            public class RootObject
            {
                public List<Card> cards { get; set; }
            }
        }

        public class Sets
        {
            public class Set
            {
                public string code { get; set; }
                public string name { get; set; }
                public string series { get; set; }
                public int totalCards { get; set; }
                public bool standardLegal { get; set; }
                public string releaseDate { get; set; }
            }

            public class RootObject
            {
                public List<Set> sets { get; set; }
            }
        }

        public static class Series
        {
            public static string XY { get { return "XY"; } }
            public static string BlackWhite { get { return "Black & White"; } }
            public static string BWBlackStarPromos { get { return "BW"; } }
            public static string HGSS { get { return "HeartGold & SoulSilver"; } }
            public static string DP { get { return "Diamond & Pearl"; } }
            public static string Platinum { get { return "Platinum"; } }
            public static string EX { get { return "EX"; } }
            public static string ECard { get { return "E-Card"; } }
            public static string Base { get { return "Base"; } }
        }

        public class Deck
        {
            public int DeckID { get; set; }
            public string Name { get; set; }
            public List<int> CardID { get; set; }
            public bool Favourited { get; set; }
        }

    }
}