using System;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;
using System.Collections.Generic;
using Android.Content;
using Android.Widget;
using HeritageWalks.Activities;
using Android.App;
using System.Threading.Tasks;

namespace HeritageWalks.Fragments
{
    public class TrailFragment : SupportFragment
    {
        private List<Trail> mValues;
        RecyclerView mRecyclerView;
        DataAPI data = new DataAPI();
        RecyclerViewAdapter mAdapter;
        ProgressDialog pd;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            pd = ProgressDialog.Show(Context, "", "Loading Trails", true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mRecyclerView = inflater.Inflate(Resource.Layout.TrailFragment, container, false) as RecyclerView;
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(mRecyclerView.Context));
            mRecyclerView.SetAdapter(new RecyclerViewAdapter(mValues));

            return mRecyclerView;
        }

        public override void OnResume()
        {
            base.OnResume();
            Task.Run(async () =>
            {
                try
                {
                    mValues = await data.GetTrailsAsync();

                    Activity.RunOnUiThread(() =>
                    {
                        mAdapter = new RecyclerViewAdapter(mValues);
                        mRecyclerView.SetAdapter(mAdapter);
                        pd.Hide();
                    });
                }
                catch (Exception)
                {

                }
            });
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
                    if (mValues != null)
                    {
                        return mValues.Count;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var viewHolder = holder as ViewHolder;

                viewHolder._TxtViewName.Text = mValues[position].Name;
                viewHolder._TxtViewName.SetBackgroundResource(AssignColour());
                viewHolder._TxtViewTime.Text = mValues[position].Time;
                viewHolder._TxtViewLength.Text = mValues[position].Length;
                viewHolder._ImageView.SetImageResource(mValues[position].PictureInt);
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