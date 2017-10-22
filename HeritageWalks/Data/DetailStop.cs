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
    public class DetailStop
    {
        private string id;
        private string name;
        private string stopDesc;
        private string stopConstruct;
        private string stopLocation;
        private string stopCoordX;
        private string stopCoordY;
        private int stopImage;
        private string stopVideoURL;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string StopDesc
        {
            get { return stopDesc; }
            set { stopDesc = value; }
        }
        public string StopConstruct
        {
            get { return stopConstruct; }
            set { stopConstruct = value; }
        }
        public string StopLocation
        {
            get { return stopLocation; }
            set { stopLocation = value; }
        }
        public string StopCoordX
        {
            get { return stopCoordX; }
            set { stopCoordX = value; }
        }
        public string StopCoordY
        {
            get { return stopCoordY; }
            set { stopCoordY = value; }
        }
        public int StopImage
        {
            get { return stopImage; }
            set { stopImage = value; }
        }
        public string StopVideoURL
        {
            get { return stopVideoURL; }
            set { stopVideoURL = value; }
        }
    }
}