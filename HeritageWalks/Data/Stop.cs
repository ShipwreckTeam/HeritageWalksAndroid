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
        private int id;
        private string name;
        private string shortDesc;
        private string built;
        private int pictureInt;

        public Stop(int id, string name, string shortDesc, string built, int pictureInt)
        {
            this.id = id;
            this.name = name;
            this.shortDesc = shortDesc;
            this.built = built;
            this.pictureInt = pictureInt;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { Name = value; }
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
    }
}