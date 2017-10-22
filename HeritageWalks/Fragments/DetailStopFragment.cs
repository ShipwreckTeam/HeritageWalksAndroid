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
        private List<DetailStop> mValues;
        RecyclerView mRecyclerView;
        DataAPI data = new DataAPI();
        RecyclerViewAdapter mAdapter;
        ProgressDialog pd;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            pd = ProgressDialog.Show(Context, "", "Loading Stop Details", true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mRecyclerView = inflater.Inflate(Resource.Layout.DetailStopFragment, container, false) as RecyclerView;
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
                    mValues = await data.GetDetailStopsAsync();

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

                viewHolder._ImageView.SetImageResource(mValues[position].StopImage);
                viewHolder._TxtViewId.Text = mValues[position].Id;
                viewHolder._TxtViewName.Text = mValues[position].Name;
                viewHolder._TxtViewStopDesc.Text = mValues[position].StopDesc;
                viewHolder._TxtViewStopConstruct.Text = mValues[position].StopConstruct;
                viewHolder._TxtViewStopLocation.Text = mValues[position].StopLocation;

            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DetailStop_Layout, parent, false);
                return new ViewHolder(view);
            }
        }

        public class ViewHolder : RecyclerView.ViewHolder
        {
            public View _View;
            public ImageView _ImageView;
            public TextView _TxtViewId;
            public TextView _TxtViewName;
            public TextView _TxtViewStopDesc;
            public TextView _TxtViewStopConstruct;
            public TextView _TxtViewStopLocation;

            public ViewHolder(View view) : base(view)
            {
                _View = view;

                _View.Click += (sender, e) =>
                {
                    var context = _View.Context;
                    Intent intent = new Intent(context, typeof(DetailStopActivity));
                    context.StartActivity(intent);
                };

                _ImageView = view.FindViewById<ImageView>(Resource.Id.stop_img);
                _TxtViewId = view.FindViewById<TextView>(Resource.Id.txtId_detail);
                _TxtViewName = view.FindViewById<TextView>(Resource.Id.txtName_detail);
                _TxtViewStopDesc = view.FindViewById<TextView>(Resource.Id.txtStopDesc);
                _TxtViewStopConstruct = view.FindViewById<TextView>(Resource.Id.txtStopConstruct);
                _TxtViewStopLocation = view.FindViewById<TextView>(Resource.Id.txtStopLocation);

            }
        }

    }
}
