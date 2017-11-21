using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using System.Collections.Generic;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using SupportFragment = Android.Support.V4.App.Fragment;
using System;
using System.Threading.Tasks;

namespace HeritageWalks.Fragments
{
    public class MapsFragment : SupportFragment, IOnMapReadyCallback
    {
        private GoogleMap mMap;
        private string mTrailId;
        private DataAPI mData = new DataAPI();
        private List<Stop> mValues = new List<Stop>();
        private List<Stop> mStopList = new List<Stop>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mTrailId = Arguments.GetString("Trail ID");
            GetStopData();
            SetUpMap();
        }

        private void GetStopData()
        {
            Task.Run(async() =>
            {
                try
                {
                    mValues = await mData.GetStopsAsync();

                    for (int i = 0; i < mValues.Count; i++)
                    {
                        if (mValues[i].TrailId == Convert.ToInt32(mTrailId))
                        {
                            mStopList.Add(mValues[i]);
                        }
                    }
                }
                catch (Exception)
                {

                }
            });
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

            Task.Run( () =>
            {
                Activity.RunOnUiThread(async () =>
                {
                    try
                    {
                        mValues = await mData.GetStopsAsync();

                        for (int i = 0; i < mValues.Count; i++)
                        {
                            if (mValues[i].TrailId == Convert.ToInt32(mTrailId))
                            {
                                mStopList.Add(mValues[i]);
                            }
                        }

                        if (mStopList.Count > 0)
                        {
                            SetUpCoords(mMap);
                        }
                    }
                    catch (Exception)
                    {

                    }
                });             
            });

            //Optional fluff to do with how the user can interact with the maps
            mMap.UiSettings.ZoomControlsEnabled = true; //Allow people to control their own Zooming
            mMap.UiSettings.CompassEnabled = true;
            mMap.UiSettings.ZoomGesturesEnabled = false; //disables people double tapping the screen to zoom in
            mMap.UiSettings.MapToolbarEnabled = false; //disables two buttons that would create intents in the actual google maps application
        }

        private void SetUpCoords(GoogleMap googleMap)
        {
            LatLng TrailOneStopOne = new LatLng(Convert.ToDouble(mStopList[0].CoordX), Convert.ToDouble(mStopList[0].CoordY));
            LatLng TrailOneStopTwo = new LatLng(Convert.ToDouble(mStopList[1].CoordX), Convert.ToDouble(mStopList[1].CoordY));
            LatLng TrailOneStopThree = new LatLng(Convert.ToDouble(mStopList[2].CoordX), Convert.ToDouble(mStopList[2].CoordY)); 
            LatLng TrailOneStopFour = new LatLng(Convert.ToDouble(mStopList[3].CoordX), Convert.ToDouble(mStopList[3].CoordY)); ;
            LatLng TrailOneStopFive = new LatLng(Convert.ToDouble(mStopList[4].CoordX), Convert.ToDouble(mStopList[4].CoordY)); ;

            MarkerOptions markerOptions = new MarkerOptions();
            MarkerOptions markerOptions2 = new MarkerOptions();
            MarkerOptions markerOptions3 = new MarkerOptions();
            MarkerOptions markerOptions4 = new MarkerOptions();
            MarkerOptions markerOptions5 = new MarkerOptions();

            markerOptions.SetPosition(TrailOneStopOne);
            markerOptions2.SetPosition(TrailOneStopTwo);
            markerOptions3.SetPosition(TrailOneStopThree);
            markerOptions4.SetPosition(TrailOneStopFour);
            markerOptions5.SetPosition(TrailOneStopFive);

            markerOptions.SetTitle(mStopList[0].StopId + ". " + mStopList[0].Name);
            markerOptions2.SetTitle(mStopList[1].StopId + ". " + mStopList[1].Name);
            markerOptions3.SetTitle(mStopList[2].StopId + ". " + mStopList[2].Name);
            markerOptions4.SetTitle(mStopList[3].StopId + ". " + mStopList[3].Name);
            markerOptions5.SetTitle(mStopList[4].StopId + ". " + mStopList[4].Name);

            googleMap.AddMarker(markerOptions);
            googleMap.AddMarker(markerOptions2);
            googleMap.AddMarker(markerOptions3);
            googleMap.AddMarker(markerOptions4);
            googleMap.AddMarker(markerOptions5);

            //commands for centering the camera on startup to focus on the pre-existing marker
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(TrailOneStopOne, 15); //This is a preset location and zoom for the following command to call
            mMap.MoveCamera(camera); //calls the above coordinates and zoom level to move the camera too
        }
    }
}