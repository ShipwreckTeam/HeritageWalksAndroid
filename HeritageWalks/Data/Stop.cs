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
    public class Stop
    {
        public string id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string built { get; set; }
        public int pictureInt { get; set; }
    }
}