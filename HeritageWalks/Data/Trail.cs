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
        private int trailID;
        private string name;
        private string time;
        private string length;
        private string imageName;

        public int TrailID
        {
            get { return trailID; }
            set { trailID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public string Length
        {
            get { return length; }
            set { length = value; }
        }
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }
    }
}