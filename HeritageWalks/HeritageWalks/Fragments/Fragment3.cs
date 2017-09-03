using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;


namespace HeritageWalks.Fragments
{
    public class Fragment3 : SupportFragment, IOnMapReadyCallback
    {
        private GoogleMap _Map;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetUpMap();
        }

        private void SetUpMap()
        {
            if (_Map == null)
            {
                FragmentManager.FindFragmentById(Resource.Id.map);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.Fragment3, container, false);
            SetUpMap();
            return view;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            MapsInitializer.Initialize(this.Activity);
            LatLng sydney = new LatLng(-33.852, 151.211);
            googleMap.AddMarker(new MarkerOptions().SetPosition(sydney));
            googleMap.MoveCamera(CameraUpdateFactory.NewLatLng(sydney));
        }
    }
}