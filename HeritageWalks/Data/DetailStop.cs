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
    class DetailStop
    {
        public string id { get; set; }
        public string name { get; set; }
        public string stopDesc { get; set; }
        public string stopConstruct { get; set; }
        public string stopLocation { get; set; }
        public string stopCoordX { get; set; }
        public string stopCoordY { get; set; }
        public int stopImage { get; set; }
        public string stopVideoURL { get; set; }
    }
}