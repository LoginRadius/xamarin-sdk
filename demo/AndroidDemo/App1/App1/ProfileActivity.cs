using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinSDK.Api.Authentication;
using XamarinSDK.Api.SocialLogin;
using XamarinSDK.Api.PhoneAuthentication;

namespace App1
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : Activity
    {
        string apikey;
        TextView firstname, lastname, email, uid;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Context context = this;
            // Get the Resources object from our context
            Android.Content.Res.Resources res = context.Resources;
            SetContentView(Resource.Layout.profile);
            string access_token = Intent.GetStringExtra("access_token") ?? "access_token value is null";
            apikey = res.GetString(Resource.String.apikey);
            // Create your application here
            firstname = FindViewById<TextView>(Resource.Id.firstname);
            lastname = FindViewById<TextView>(Resource.Id.lastname);
            email = FindViewById<TextView>(Resource.Id.email);
            uid = FindViewById<TextView>(Resource.Id.uid);
            GetReadAllProfiles(apikey, access_token);
           
        }

        public async void GetReadAllProfiles(string apikey, string access_token)
        {
            await ReadAllProfilesAPI.GetReadAllProfiles(apikey, access_token, response => {
                Toast.MakeText(this, "Hello"+Convert.ToString(response.FirstName), ToastLength.Long).Show();
                firstname.Text = "FirstName = "+response.FirstName;
                lastname.Text = "LastName = " + response.LastName;
                email.Text = "Email = " + response.Email[0].Value;
                uid.Text = "UID = " + response.Uid;
                
            }, (error) => {
                Toast.MakeText(this, error.description, ToastLength.Long).Show();
            });
        }

    }
}