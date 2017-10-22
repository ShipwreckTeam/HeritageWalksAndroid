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
        private List<Stop> mValues;
        RecyclerView mRecyclerView;
        DataAPI data = new DataAPI();
        RecyclerViewAdapter mAdapter;
        ProgressDialog pd;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            pd = ProgressDialog.Show(Context, "", "Loading stops", true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {          
            mRecyclerView = inflater.Inflate(Resource.Layout.StopFragment, container, false) as RecyclerView;
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
                    mValues = await data.GetStopsAsync();
                   
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
            private List<Stop> mValues;

            public RecyclerViewAdapter(List<Stop> items)
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

                viewHolder._ImageView.SetImageResource(mValues[position].PictureInt);
                viewHolder._TxtViewId.Text = mValues[position].Id.ToString();
                viewHolder._TxtViewName.Text = mValues[position].Name;
                viewHolder._TxtViewShortDesc.Text = mValues[position].ShortDesc;
                viewHolder._TxtViewBuilt.Text = mValues[position].Built;
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.stop_row, parent, false);
                return new ViewHolder(view);
            }
        }

        public class ViewHolder : RecyclerView.ViewHolder
        {
            public View _View;
            public ImageView _ImageView;
            public TextView _TxtViewId;
            public TextView _TxtViewName;
            public TextView _TxtViewShortDesc;
            public TextView _TxtViewBuilt;

            public ViewHolder(View view) : base(view)
            {
                _View = view;

                _View.Click += (sender, e) =>
                {
                    var context = _View.Context;
                    Intent intent = new Intent(context, typeof(DetailStopActivity));
                    context.StartActivity(intent);
                };

                _ImageView = view.FindViewById<ImageView>(Resource.Id.view_img);
                _TxtViewId = view.FindViewById<TextView>(Resource.Id.txtId);
                _TxtViewName = view.FindViewById<TextView>(Resource.Id.txtName);
                _TxtViewShortDesc = view.FindViewById<TextView>(Resource.Id.txtShortDesc);
                _TxtViewBuilt = view.FindViewById<TextView>(Resource.Id.txtBuilt);

            }
        }

    }
}