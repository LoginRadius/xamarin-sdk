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
using XamarinSDK.Models.UserProfile;
using XamarinSDK.Api.Authentication;

namespace App1
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        string apikey, verificationurl;
        string FirstNametext, LastNametext, passwordtext, emiltext;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Context context = this;
            // Get the Resources object from our context
            Android.Content.Res.Resources res = context.Resources;
            SetContentView(Resource.Layout.register);
            string sott = Intent.GetStringExtra("sott") ?? "please-go-back-and-put-sott-value";
            
            apikey = res.GetString(Resource.String.apikey);
            verificationurl = res.GetString(Resource.String.verificationurl);

            EditText email = FindViewById<EditText>(Resource.Id.email);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            EditText FirstName = FindViewById<EditText>(Resource.Id.firstname);
            EditText LastName = FindViewById<EditText>(Resource.Id.lastname);
            email.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                emiltext = e.Text.ToString();
             };
            password.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                passwordtext = e.Text.ToString();
            };
            FirstName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                FirstNametext = e.Text.ToString();
            };
            LastName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                LastNametext = e.Text.ToString();
            };
            Button register = FindViewById<Button>(Resource.Id.register);

            register.Click += delegate
            {
                UserIdentityCreateModel user = new UserIdentityCreateModel();
                user.FirstName = FirstNametext;
                user.LastName = LastNametext;
                user.Password = passwordtext;
               
                Email email1 = new Email();
                email1.Type = "Primary";
                email1.Value = emiltext;
                user.Email = new List<Email>();
                user.Email.Add(email1);
                GetUserRegistrationbyEmail(apikey, sott, verificationurl, user);
            };

            
        }

        public async void GetUserRegistrationbyEmail(string apikey, string sott, string verificationurl,UserIdentityCreateModel user)
        {
          

            await UserRegistrationbyEmailAPI.GetUserRegistrationbyEmail(apikey, sott, verificationurl, "", user, response => {
                Toast.MakeText(this, "Please Verify Your Email Address", ToastLength.Long).Show();   // Success event
            }, (error) => {
                Toast.MakeText(this, error.description, ToastLength.Long).Show();                   // Failure event
            });
        }
    }
}