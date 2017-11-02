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
using System;

namespace HeritageWalks.Fragments
{
    public class DetailStopFragment : SupportFragment
    {
        private List<DetailStop> mValues = new List<DetailStop>();
        private List<DetailStop> mDetailStopList = new List<DetailStop>();
        private string mTrailId;
        private string mStopId;

        private RecyclerView mRecyclerView;
        private DataAPI mData = new DataAPI();
        private RecyclerViewAdapter mAdapter;
        private ProgressDialog mProgressBar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mTrailId = Arguments.GetString("Trail ID");
            mStopId = Arguments.GetString("Stop ID");
            mProgressBar = ProgressDialog.Show(Context, "", "Loading Stop Details", true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mRecyclerView = inflater.Inflate(Resource.Layout.DetailStopFragment, container, false) as RecyclerView;
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(mRecyclerView.Context));

            Task.Run(() =>
            {
                try
                {
                    Activity.RunOnUiThread(async () =>
                    {
                        mValues = await mData.GetDetailStopsAsync();
                        for (int i = 0; i < mValues.Count; i++)
                        {
                            if (mValues[i].TrailId == Convert.ToInt32(mTrailId) && mValues[i].StopId == Convert.ToInt32(mStopId))
                            {
                                mDetailStopList.Add(mValues[i]);
                            }
                        }
                        mAdapter = new RecyclerViewAdapter(mDetailStopList);
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
            private List<DetailStop> mValues;

            public RecyclerViewAdapter(List<DetailStop> items)
            {
                mValues = items;
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

                viewHolder.mImageView.SetImageResource(mValues[position].StopImage);
                viewHolder.mTxtViewId.Text = mValues[position].StopId.ToString();
                viewHolder.mTxtViewName.Text = mValues[position].Name;
                viewHolder.mTxtViewStopDesc.Text = mValues[position].StopDesc;
                viewHolder.mTxtViewStopConstruct.Text = mValues[position].StopConstruct;
                viewHolder.mTxtViewStopLocation.Text = mValues[position].StopLocation;
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DetailStop_Layout, parent, false);
                return new ViewHolder(view);
            }
        }

        public class ViewHolder : RecyclerView.ViewHolder
        {
            public View mView;
            public ImageView mImageView;
            public TextView mTxtViewId;
            public TextView mTxtViewName;
            public TextView mTxtViewStopDesc;
            public TextView mTxtViewStopConstruct;
            public TextView mTxtViewStopLocation;

            public ViewHolder(View view) : base(view)
            {
                mView = view;

                mView.Click += (sender, e) =>
                {

                };

                mImageView = view.FindViewById<ImageView>(Resource.Id.stop_img);
                mTxtViewId = view.FindViewById<TextView>(Resource.Id.txtId_detail);
                mTxtViewName = view.FindViewById<TextView>(Resource.Id.txtName_detail);
                mTxtViewStopDesc = view.FindViewById<TextView>(Resource.Id.txtStopDesc);
                mTxtViewStopConstruct = view.FindViewById<TextView>(Resource.Id.txtStopConstruct);
                mTxtViewStopLocation = view.FindViewById<TextView>(Resource.Id.txtStopLocation);
            }
        }

    }
}
