using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace PokemonTCGMaster
{
    public class DataHelper
    {
        public static string databasePath { get { return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/PokemonTCGMaster.db3"; }}

        public class apiCards
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

        public class myCards
        {
            public class Card
            {
                [PrimaryKey, AutoIncrement]
                public int id { get; set; }
                public string name { get; set; }
                public int nationalPokedexNumber { get; set; }
                public string imageUrl { get; set; }
                public int subtype { get; set; }
                public int supertype { get; set; }
                public string hp { get; set; }
                //public List<string> retreatCost { get; set; }
                public string number { get; set; }
                public string artist { get; set; }
                public string rarity { get; set; }
                public string series { get; set; }
                public string set { get; set; }
                public string setCode { get; set; }
                public string text { get; set; }
            }

            public class Types
            {
                [PrimaryKey, AutoIncrement]
                public int id { get; set; }
                public string text { get; set; }
            }

            public class CardTypes
            {
                public int cardId { get; set; }
                public int typeId { get; set; }
            }

            public class Attack
            {
                [PrimaryKey, AutoIncrement]
                public int id { get; set; }
                public List<string> cost { get; set; }
                public string name { get; set; }
                public string text { get; set; }
                public string damage { get; set; }
                public int convertedEnergyCost { get; set; }
            }

            public class CardAttacks
            {
                public int cardId { get; set; }
                public int attackId { get; set; }
            }

            public class Weakness
            {
                [PrimaryKey, AutoIncrement]
                public int id { get; set; }
                public string type { get; set; }
                public string value { get; set; }
            }

            public class CardWeaknesses
            {
                public int cardId { get; set; }
                public int weaknessId { get; set; }
            }

            public class Ability
            {
                [PrimaryKey, AutoIncrement]
                public int id { get; set; }
                public string name { get; set; }
                public string text { get; set; }
            }

            public class CardAbilities
            {
                public int cardId { get; set; }
                public int abilityId { get; set; }
            }

            public class Resistance
            {
                [PrimaryKey, AutoIncrement]
                public int id { get; set; }
                public string type { get; set; }
                public string value { get; set; }
            }

            public class CardResistances
            {
                public int cardId { get; set; }
                public int resistanceId { get; set; }
            }

            public class RetreatCost
            {
                [PrimaryKey, AutoIncrement]
                public int id { get; set; }
                public string value { get; set; }
            }

            public class CardRetreatCost
            {
                public int cardId { get; set; }
                public int retreatCostId { get; set; }
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

        public class Series
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

        public class PokemonTypes
        {
            public static string Colourless { get { return "Colourless"; } }
            public static string Fighting { get { return "Fighting"; } }
            public static string Psychic { get { return "Psychic"; } }
            public static string Fire { get { return "Fire"; } }
            public static string Water { get { return "Water"; } }
            public static string Grass { get { return "Grass"; } }
            public static string Electric { get { return "Electric"; } }
            public static string Steel { get { return "Steel"; } }
            public static string Dark { get { return "Dark"; } }
            public static string Fairy { get { return "Fairy"; } }
            public static string Dragon { get { return "Dragon"; } }
        }

        public class CardTypes
        {
            public static string Pokemon { get { return "Pokemon"; } }
            public static string Trainer { get { return "Trainer"; } }
            public static string Energy { get { return "Energy"; } }
        }

        //public static class CardSubTypes
        //{

        //}

        public class Deck
        {
            public int DeckID { get; set; }
            public string Name { get; set; }
            public List<int> CardID { get; set; }
            public bool Favourited { get; set; }
        }


    }
}