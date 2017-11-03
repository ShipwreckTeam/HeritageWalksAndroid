using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace HeritageWalks.Fragments
{
    public class MapsFragment : SupportFragment, IOnMapReadyCallback
    {
        private GoogleMap mMap;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           SetUpMap();
        }

        private void SetUpMap()
        {
            SupportMapFragment mapFrag = Activity.SupportFragmentManager.FindFragmentById(Resource.Id.map) as SupportMapFragment;
            if (mapFrag == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = Activity.SupportFragmentManager.BeginTransaction();
                mapFrag = SupportMapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, mapFrag, "map");
                fragTx.Commit();
            }

            mapFrag.GetMapAsync(this);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.MapsFragment, container, false);

            return view;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;

            //Coordinates seat
            LatLng claremontMarker1 = new LatLng(-31.9798264, 115.7799933); //Coordinates for Claremont
            LatLng claremontMarker2 = new LatLng(-31.980699, 115.7813756); //Coordinates for Claremont but a different spot

            //commands for centering the camera on startup to focus on the pre-existing marker
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(claremontMarker1, 15); //This is a preset location and zoom for the following command to call
            mMap.MoveCamera(camera); //calls the above coordinates and zoom level to move the camera too


            //Here-in includes all the options and widgets for the first marker
            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(claremontMarker1); //Latitude and Longitude of marker
            markerOptions.SetTitle("Claremont Trails"); //Title of Marker
            markerOptions.SetSnippet("Start Here"); //Subtext on marker, the smaller grey text
            mMap.AddMarker(markerOptions);

            MarkerOptions markerOptions2 = new MarkerOptions();
            markerOptions2.SetPosition(claremontMarker2);
            markerOptions2.SetTitle("Claremont Trails Finish");
            markerOptions2.SetSnippet("End Here");
            mMap.AddMarker(markerOptions2);

            //Optional fluff to do with how the user can interact with the maps
            mMap.UiSettings.ZoomControlsEnabled = true; //Allow people to control their own Zooming
            mMap.UiSettings.CompassEnabled = true;
            mMap.UiSettings.ZoomGesturesEnabled = false; //disables people double tapping the screen to zoom in
            mMap.UiSettings.MapToolbarEnabled = false; //disables two buttons that would create intents in the actual google maps application
        }
    }
}