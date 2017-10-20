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
    public class DetailStopFragment : SupportFragment
    {
        private List<DetailStop> mValuesD;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            RecyclerView recyclerView = inflater.Inflate(Resource.Layout.DetailStopFragment, container, false) as RecyclerView;
            SetUpRecyclerView(recyclerView);

            return recyclerView;
        }

        public void SetUpRecyclerView(RecyclerView recyclerView)
        {
            mValuesD = new List<DetailStop>();

            mValuesD.Add(new DetailStop() { id = "Stop 1", name = "CLAREMONT STATION", stopDesc = "Old Claremont railway station is located the quick brown fox jumps etc etc", stopConstruct = "Built in 1898", stopLocation = "Corner of Railway Parade and Stirling Highway", stopImage = AssignPicture(Resource.Drawable.stop_picture1) });
 
            recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
            recyclerView.SetAdapter(new RecyclerViewAdapter(mValuesD));
        }

        public int AssignPicture(int pictureLocation)
        {
            int picture = pictureLocation;

            return picture;
        }

        private class RecyclerViewAdapter : RecyclerView.Adapter
        {
            private List<DetailStop> mValuesD;

            public RecyclerViewAdapter(List<DetailStop> items)
            {
                mValuesD = items;
            }


            public override int ItemCount
            {
                get
                {
                    return mValuesD.Count;
                }
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var viewHolder = holder as ViewHolder;

                viewHolder._ImageView.SetImageResource(mValuesD[position].stopImage);
                viewHolder._TxtViewId.Text = mValuesD[position].id;
                viewHolder._TxtViewName.Text = mValuesD[position].name;
                viewHolder._TxtViewStopDesc.Text = mValuesD[position].stopDesc;
                viewHolder._TxtViewStopConstruct.Text = mValuesD[position].stopConstruct;
                viewHolder._TxtViewStopLocation.Text = mValuesD[position].stopLocation;

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
