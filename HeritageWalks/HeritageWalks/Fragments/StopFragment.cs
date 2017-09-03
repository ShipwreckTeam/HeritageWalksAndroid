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
    public class StopFragment : SupportFragment
    {
        private List<Stop> mValues;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            RecyclerView recyclerView = inflater.Inflate(Resource.Layout.StopFragment, container, false) as RecyclerView;
            SetUpRecyclerView(recyclerView);

            return recyclerView;
        }

        private void SetUpRecyclerView(RecyclerView recyclerView)
        {
            mValues = new List<Stop>();

            mValues.Add(new Stop() { id = "1.", name = "CLAREMONT STATION", shortDesc = "Old Claremont railway station", built = "built 1898", pictureInt = AssignPicture(Resource.Drawable.stop_picture1) });
            mValues.Add(new Stop() { id = "2.", name = "RAILWAY SIGNAL BOX", shortDesc = "Part of the old railway system", built = "built 1925", pictureInt = AssignPicture(Resource.Drawable.stop_picture2) });


            recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
            recyclerView.SetAdapter(new RecyclerViewAdapter(mValues));
        }

        public int AssignPicture(int pictureLocation)
        {
            int picture = pictureLocation;

            return picture;
        }

        public class RecyclerViewAdapter : RecyclerView.Adapter
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
                    return mValues.Count;
                }
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var viewHolder = holder as ViewHolder;

                viewHolder._ImageView.SetImageResource(mValues[position].pictureInt);
                viewHolder._TxtViewId.Text = mValues[position].id;
                viewHolder._TxtViewName.Text = mValues[position].name;
                viewHolder._TxtViewShortDesc.Text = mValues[position].shortDesc;
                viewHolder._TxtViewBuilt.Text = mValues[position].built;

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
                    Intent intent = new Intent(context, typeof(StopsActivity));
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