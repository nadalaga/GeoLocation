﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
namespace Elite
{
    public class FragmentHome : Android.Support.V4.App.Fragment
    {
        TextView lblLatitude;
        TextView lblLongitude;
      //  Location location;
        private string txtWelcome { get; set; }
        public FragmentHome(string outputWelcome) {
            this.txtWelcome = outputWelcome;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           
            // Create your fragment here
           
        }

         public async void showLocation(View fragment)
         {
             try
             {
                  var location = await Geolocation.GetLocationAsync();

                 //if (location != null)
                 //{
                 TextView welcome = fragment.FindViewById<TextView>(Resource.Id.txtWelcome);
                 welcome.Text = welcome.Text + ' ' +this.txtWelcome;


                 if (location != null)
                 {
                     lblLatitude.Text = "Latitude: " + location.Latitude.ToString();
                     lblLongitude.Text = "Longitude:" + location.Longitude.ToString();
                 }

                 //  welcome.Text = ($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                 //  }
             }
             catch (FeatureNotSupportedException)
             {
                 // Handle not supported on device exception
             }
             catch (FeatureNotEnabledException)
             {
                 // Handle not enabled on device exception
             }
             catch (PermissionException)
             {
                 // Handle permission exception
             }

         }



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
  
            base.OnCreateView(inflater, container, savedInstanceState);

            View CurrentFragment = inflater.Inflate(Resource.Layout.fragment_main, container, false);
            TextView txtWelcome =  CurrentFragment.FindViewById<TextView>(Resource.Id.txtWelcome);
            lblLatitude = CurrentFragment.FindViewById<TextView>(Resource.Id.lblLatitude);
            lblLongitude = CurrentFragment.FindViewById<TextView>(Resource.Id.lblLongitude);
           showLocation(CurrentFragment);

            //Add Event for Open Map button
            Button btnOpenMap = CurrentFragment.FindViewById<Button>(Resource.Id.btnOpenGoogleMap);
            btnOpenMap.Click += btnOpenMapClick;
            return CurrentFragment;
        }

        public void btnOpenMapClick(object sender, EventArgs e) {
            string latitude = lblLatitude.Text;
            string longitude = lblLongitude.Text;
            var geoUri = Android.Net.Uri.Parse("geo:"+latitude+','+longitude);
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }
    }
}