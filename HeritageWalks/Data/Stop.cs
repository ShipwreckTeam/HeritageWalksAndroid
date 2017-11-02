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
        private int stopId;
        private string name;
        private string shortDesc;
        private string built;
        private int pictureInt;
        private int trailId;

        public int StopId
        {
            get { return stopId; }
            set { stopId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string ShortDesc
        {
            get { return shortDesc; }
            set { shortDesc = value; }
        }
        public string Built
        {
            get { return built; }
            set { built = value; }
        }
        public int PictureInt
        {
            get { return pictureInt; }
            set { pictureInt = value; }
        }
        public int TrailId
        {
            get { return trailId; }
            set { trailId = value; }
        }
    }
}