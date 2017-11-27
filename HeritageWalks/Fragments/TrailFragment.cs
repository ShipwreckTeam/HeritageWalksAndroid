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
        private List<Trail> mValues = new List<Trail>();
        private RecyclerView mRecyclerView;
        private DataAPI mData = new DataAPI();
        private RecyclerViewAdapter mAdapter;
        private ProgressDialog mProgressBar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mProgressBar = ProgressDialog.Show(Context, "", "Loading Trails", true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mRecyclerView = inflater.Inflate(Resource.Layout.TrailFragment, container, false) as RecyclerView;
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(mRecyclerView.Context));

            Task.Run(() =>
            {
                try
                {
                    Activity.RunOnUiThread(async () =>
                    {
                        mValues = await mData.GetTrailsAsync();
                       
                        mAdapter = new RecyclerViewAdapter(mValues);
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

        public class RecyclerViewAdapter : RecyclerView.Adapter
        {
            private List<Trail> mValues;
            List<int> mColourList = new List<int>();
            private int mColourIndex;

            public RecyclerViewAdapter(List<Trail> items)
            {
                mValues = items;
                mColourIndex = 0;
                mColourList.Add(Resource.Color.orange);
                mColourList.Add(Resource.Color.purple);
                mColourList.Add(Resource.Color.green);
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

                viewHolder.mTxtViewName.Text = mValues[position].Name;
                viewHolder.mTxtViewName.SetBackgroundResource(AssignColour());
                viewHolder.mTxtViewTime.Text = mValues[position].Time;
                viewHolder.mTxtViewLength.Text = mValues[position].Length;

                int imageInt = (int)typeof(Resource.Drawable).GetField(mValues[position].ImageName).GetValue(null);
                viewHolder.mImageView.SetImageResource(imageInt);
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.trail_row, parent, false);
                return new ViewHolder(view);
            }

            public int AssignColour()
            {
                int colour;

                if (mColourIndex > mColourList.Count)
                {
                    mColourIndex = 0;
                }

                colour = mColourList[mColourIndex];
                mColourIndex++;
                return colour;
            }
        }

        public class ViewHolder : RecyclerView.ViewHolder
        {
            public View mView;
            public ImageView mImageView;
            public TextView mTxtViewName;
            public TextView mTxtViewTime;
            public TextView mTxtViewLength;

            public ViewHolder(View view) : base(view)
            {
                mView = view;

                mView.Click += (sender, e) =>
                {
                    var trailId = LayoutPosition;
                    trailId++;
                    var context = mView.Context;
                    Intent intent = new Intent(context, typeof(StopsActivity));
                    intent.PutExtra("Trail ID", Convert.ToString(trailId));
                    context.StartActivity(intent);
                };

                mImageView = view.FindViewById<ImageView>(Resource.Id.view_img);
                mTxtViewName = view.FindViewById<TextView>(Resource.Id.txtName);
                mTxtViewTime = view.FindViewById<TextView>(Resource.Id.txtTime);
                mTxtViewLength = view.FindViewById<TextView>(Resource.Id.txtLength);
            }
        }

    }
}