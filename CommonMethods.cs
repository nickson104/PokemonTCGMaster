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
    public class CommonMethods
    {
        public static string StringListToString(List<string> texts)
        {
            string retVal = string.Empty;
            if (texts != null)
            {
                foreach (var t in texts)
                {
                    retVal = retVal += t;
                }
            }
            return retVal;
        }




    }
}