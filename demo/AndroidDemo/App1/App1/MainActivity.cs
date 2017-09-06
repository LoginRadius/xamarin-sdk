using Android.App;
using Android.Widget;
using Android.OS;

using Android.Content;
using System;
using XamarinSDK.Api.Authentication;
using System.Collections.Generic;
using XamarinSDK.Api.PhoneAuthentication;

namespace App1
{
    [Activity(MainLauncher = true, NoHistory = true,Theme = "@style/MyTheme")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            string sott = ""; //put your sott

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            

            Button login = FindViewById<Button>(Resource.Id.login);
            Button register = FindViewById<Button>(Resource.Id.register);
            Button forgotpassword = FindViewById<Button>(Resource.Id.forgot);
            login.Click += delegate
            {
                var activity2 = new Intent(this, typeof(LoginActivity));
                StartActivity(activity2);
            };

            register.Click += delegate
            {
                var activity2 = new Intent(this, typeof(RegisterActivity));
                activity2.PutExtra("sott", sott);
                StartActivity(activity2);
            };

            forgotpassword.Click += delegate
            {
                 var activity2 = new Intent(this, typeof(ForgotPasswordActivity));
                 StartActivity(activity2);
               
            };
        }

    }


}