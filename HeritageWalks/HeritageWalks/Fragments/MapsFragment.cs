using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;


namespace HeritageWalks.Fragments
{
    public class MapsFragment : SupportFragment, IOnMapReadyCallback
    {
        private GoogleMap _Map;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetUpMap();
        }

        private void SetUpMap()
        {
            /* if (_Map == null)
             {
                 FragmentManager.FindFragmentById(Resource.Id.map);
             }*/

            var _mapFragment = FragmentManager.FindFragmentById(Resource.Id.map) as SupportMapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeSatellite)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = SupportMapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.MapsFragment, container, false);
            SetUpMap();
            return view;
        }

   
        public void OnMapReady(GoogleMap map)
        {
            _Map = map;

            LatLng sydney = new LatLng(-33.852, 151.211);
            map.AddMarker(new MarkerOptions().SetPosition(sydney));
            map.MoveCamera(CameraUpdateFactory.NewLatLng(sydney));
        }
    }
}