using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;
using System.Collections.Generic;
using Android.Content;
using Android.Widget;
using HeritageWalks.Activities;
using System.Threading.Tasks;
using System;
using Android.App;

namespace HeritageWalks.Fragments
{
    public class StopFragment : SupportFragment
    {
        private List<Stop> mValues = new List<Stop>();
        private List<Stop> mTrailStops = new List<Stop>();
        private string mTrailId;

        private RecyclerView mRecyclerView;
        private DataAPI mData = new DataAPI();
        private RecyclerViewAdapter mAdapter;
        private ProgressDialog mProgressBar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mTrailId = Arguments.GetString("Trail ID");
            mProgressBar = ProgressDialog.Show(Context, "", "Loading stops", true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {          
            mRecyclerView = inflater.Inflate(Resource.Layout.StopFragment, container, false) as RecyclerView;
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(mRecyclerView.Context));

            Task.Run(() =>
            {
                try
                {
                    Activity.RunOnUiThread(async () =>
                    {
                        mValues = await mData.GetStopsAsync();
                        for (int i = 0; i < mValues.Count; i++)
                        {
                            if (mValues[i].TrailId == Convert.ToInt32(mTrailId))
                            {
                                mTrailStops.Add(mValues[i]);
                            }
                        }
                        mAdapter = new RecyclerViewAdapter(mTrailStops, mTrailId);
                        mRecyclerView.SetAdapter(mAdapter);
                        mProgressBar.Hide();
                    });
                }
                catch (Exception)
                {

                }
            });

            return mRecyclerView;
        }

        private class RecyclerViewAdapter : RecyclerView.Adapter
        {
            private List<Stop> mValues;
            private string mTrailId;

            public RecyclerViewAdapter(List<Stop> items, string trailId)
            {
                mValues = items;
                mTrailId = trailId;
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
                int imageInt = (int)typeof(Resource.Drawable).GetField(mValues[position].ImageName).GetValue(null);

                viewHolder.mImageView.SetImageResource(imageInt);
                //viewHolder.mTxtViewId.Text = mValues[position].StopId.ToString();
                viewHolder.mTxtViewId.Text = (position + 1) + ". ".ToString();
                viewHolder.mTxtViewName.Text = mValues[position].Name;
                viewHolder.mTxtViewShortDesc.Text = mValues[position].ShortDesc;
                viewHolder.mTxtViewBuilt.Text = "Built: "  + mValues[position].Built;
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.stop_row, parent, false);
                return new ViewHolder(view, mTrailId, mValues);
            }
        }

        public class ViewHolder : RecyclerView.ViewHolder
        {
            public View mView;
            public ImageView mImageView;
            public TextView mTxtViewId;
            public TextView mTxtViewName;
            public TextView mTxtViewShortDesc;
            public TextView mTxtViewBuilt;

            public ViewHolder(View view, String trailId, List<Stop> stopList) : base(view)
            {
                mView = view;

                mView.Click += (sender, e) =>
                {
                    //var stopId = Convert.ToInt32(mTxtViewId.Text);
                    var stopId = stopList[LayoutPosition].StopId;
                    var context = mView.Context;
                    Intent intent = new Intent(context, typeof(DetailStopActivity));
                    intent.PutExtra("Trail ID", trailId);
                    intent.PutExtra("Stop ID", Convert.ToString(stopId));
                    context.StartActivity(intent);
                };

                mImageView = view.FindViewById<ImageView>(Resource.Id.view_img);
                mTxtViewId = view.FindViewById<TextView>(Resource.Id.txtId);
                mTxtViewName = view.FindViewById<TextView>(Resource.Id.txtName);
                mTxtViewShortDesc = view.FindViewById<TextView>(Resource.Id.txtShortDesc);
                mTxtViewBuilt = view.FindViewById<TextView>(Resource.Id.txtBuilt);
            }
        }

    }
}