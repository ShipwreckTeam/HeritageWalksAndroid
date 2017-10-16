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

namespace HeritageWalks
{
    public class Trail
    {
        public string name { get; set; }
        public string time { get; set; }
        public string length { get; set; }
        public int pictureName { get; set; }
    }
}