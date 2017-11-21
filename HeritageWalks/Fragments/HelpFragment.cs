using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace HeritageWalks.Fragments
{
    class HelpFragment : SupportFragment
    {
        private RecyclerView mRecyclerView;
        private ProgressDialog mProgressBar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //mProgressBar = ProgressDialog.Show(Context, "", "Loading Help", true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mRecyclerView = inflater.Inflate(Resource.Layout.HelpFragment, container, false) as RecyclerView;
            mRecyclerView.SetLayoutManager(new LinearLayoutManager(mRecyclerView.Context));

            return mRecyclerView;
        }




    }
}