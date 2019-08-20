using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using XamarinSDK.Api.Authentication;

namespace App1
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        string apikey, appname;
        string emiltext, passwordtext;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Context context = this;
            // Get the Resources object from our context
            Android.Content.Res.Resources res = context.Resources;
            SetContentView(Resource.Layout.login);
            apikey = res.GetString(Resource.String.apikey);
            appname = res.GetString(Resource.String.appname);
           
            EditText email = FindViewById<EditText>(Resource.Id.email);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            email.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                emiltext = e.Text.ToString();
            };
            password.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                passwordtext = e.Text.ToString();
            };
            Button login = FindViewById<Button>(Resource.Id.dologin);
            ImageButton faceboologin = FindViewById<ImageButton>(Resource.Id.fb);
            login.Click += delegate
            {
                GetLoginbyEmail(emiltext, passwordtext);
            };

            faceboologin.Click += delegate
            {
                var activity2 = new Intent(this, typeof(WebActivity));
                activity2.PutExtra("apikey", apikey);
                activity2.PutExtra("appname", appname);
                activity2.PutExtra("provider", "facebook");
                StartActivity(activity2);
            };
        }

        public async void GetLoginbyEmail(string email,string password)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("apikey", apikey);
            data.Add("email", email);
            data.Add("password", password);
            
            await LoginbyEmailAPI.GetLoginbyEmail(data, response => {
                                                                                                 // Success event
                var activity2 = new Intent(this, typeof(ProfileActivity));
                activity2.PutExtra("access_token", Convert.ToString(response.access_token));
                StartActivity(activity2);
            }, (error) => {
                Toast.MakeText(this, error.description, ToastLength.Long).Show();                 // Failure event   
            });
        }
    }
}