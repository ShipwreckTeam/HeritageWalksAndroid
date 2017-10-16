using System;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;
using System.Collections.Generic;
using Android.Content;
using Android.Widget;
using HeritageWalks.Activities;

namespace HeritageWalks.Fragments
{
    public class TrailFragment : SupportFragment
    {
        private List<Trail> mValues;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            RecyclerView recyclerView = inflater.Inflate(Resource.Layout.TrailFragment, container, false) as RecyclerView;
            SetUpRecyclerView(recyclerView);

            return recyclerView;
        }

        private void SetUpRecyclerView(RecyclerView recyclerView)
        {
            mValues = new List<Trail>();

            mValues.Add(new Trail() { name = "Trail of memories", time = "1.5hrs", length = "3.0km", pictureName = Resource.Drawable.picture1 });
            mValues.Add(new Trail() { name = "Cobblers and Convicts", time = "0.6hrs", length = "2.5km", pictureName = Resource.Drawable.picture2 });
            mValues.Add(new Trail() { name = "Rediscover the terrace", time = "2.5hrs", length = "3.5km", pictureName = Resource.Drawable.picture3 });

            recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
            recyclerView.SetAdapter(new RecyclerViewAdapter(mValues));
        }

        public class RecyclerViewAdapter : RecyclerView.Adapter
        {
            private List<Trail> mValues;
            List<int> colourList = new List<int>();
            private int _colourIndex;

            public RecyclerViewAdapter(List<Trail> items)
            {
                mValues = items;
                _colourIndex = 0;
                colourList.Add(Resource.Color.orange);
                colourList.Add(Resource.Color.purple);
                colourList.Add(Resource.Color.green);
            }

            public override int ItemCount
            {
                get
                {
                    return mValues.Count;
                }
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var viewHolder = holder as ViewHolder;

                viewHolder._TxtViewName.Text = mValues[position].name;
                viewHolder._TxtViewName.SetBackgroundResource(AssignColour());
                viewHolder._TxtViewTime.Text = mValues[position].time;
                viewHolder._TxtViewLength.Text = mValues[position].length;
                viewHolder._ImageView.SetImageResource(mValues[position].pictureName);



            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.trail_row, parent, false);
                return new ViewHolder(view);
            }

            public int AssignColour()
            {
                int colour;

                if (_colourIndex > colourList.Count)
                {
                    _colourIndex = 0;
                }

                colour = colourList[_colourIndex];
                _colourIndex++;
                return colour;
            }
        }

        public class ViewHolder : RecyclerView.ViewHolder
        {
            public View _View;
            public ImageView _ImageView;
            public TextView _TxtViewName;
            public TextView _TxtViewTime;
            public TextView _TxtViewLength;

            public ViewHolder(View view) : base(view)
            {
                _View = view;

                _View.Click += (sender, e) =>
                {
                    var context = _View.Context;
                    Intent intent = new Intent(context, typeof(StopsActivity));
                    context.StartActivity(intent);
                };

                _ImageView = view.FindViewById<ImageView>(Resource.Id.view_img);
                _TxtViewName = view.FindViewById<TextView>(Resource.Id.txtName);
                _TxtViewTime = view.FindViewById<TextView>(Resource.Id.txtTime);
                _TxtViewLength = view.FindViewById<TextView>(Resource.Id.txtLength);
            }
        }

    }
}