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

namespace App1
{
    [Activity(Label = "ForgotPasswordActivity")]
    public class ForgotPasswordActivity : Activity
    {

        string apikey, emiltext;
        string verificationurl;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.forgotPassword);
            Context context = this;
            // Get the Resources object from our context
            Android.Content.Res.Resources res = context.Resources;
            apikey = res.GetString(Resource.String.apikey);
            verificationurl = res.GetString(Resource.String.verificationurl);
            EditText email = FindViewById<EditText>(Resource.Id.email);
            email.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                emiltext = e.Text.ToString();
            };
            
            // Create your application here
            Button forgot = FindViewById<Button>(Resource.Id.forgot);

            forgot.Click += delegate
            {
                GetForgotPassword(emiltext);
            };
        }

        public async void GetForgotPassword(string emiltext)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("apikey", apikey);
            data.Add("email", emiltext);
            data.Add("resetpasswordurl", verificationurl);
            //data.Add("emailtemplate", "xxxxxx"); (optinal)

            await ForgotPasswordAPI.GetForgotPassword(data, response => {
                Toast.MakeText(this, "Please check your email", ToastLength.Long).Show();
                
            }, (error) => {
                Toast.MakeText(this, error.description, ToastLength.Long).Show();              // Failure event   
            });
        }
    }
}