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
        private string fullDesc;
        private string location;
        private string coordX;
        private string coordY;
        private string built;
        private string imageName;
        private string videoURL;
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

        public string FullDesc
        {
            get { return fullDesc; }
            set { fullDesc = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string CoordX
        {
            get { return coordX; }
            set { coordX = value; }
        }
        public string CoordY
        {
            get { return coordY; }
            set { coordY = value; }
        }

        public string Built
        {
            get { return built; }
            set { built = value; }
        }
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }
        public int TrailId
        {
            get { return trailId; }
            set { trailId = value; }
        }
    }
}