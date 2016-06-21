using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using LoginRadius.SDK;

namespace LoginRadius.Android.Sample
{
	[Activity (Label = "LoginRadius.Android.Sample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		Button facebookButton;
		Button twitterButton;
		Button signUpButton;
		Button signInButton;
		Button logoutButton;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Initialize LoginRadius SDK
			LoginRadiusSDK.ApiKey = "<your loginradius API Key>";
			LoginRadiusSDK.SiteName = "<your loginradius sitename>";


			// Get our button from the layout resource,
			// and attach an event to it
			facebookButton = FindViewById<Button> (Resource.Id.facebook);
			twitterButton = FindViewById<Button> (Resource.Id.twitter);
			signUpButton = FindViewById<Button> (Resource.Id.signup);
			signInButton = FindViewById<Button> (Resource.Id.signin);
			logoutButton = FindViewById<Button> (Resource.Id.logout);

			// If there is no valid access token i.e user is opening app for the first time or user is logged out
			if (LoginRadiusSettings.LoginRadiusAccessToken.Equals ("")) {
				logoutButton.Visibility = ViewStates.Invisible;
			} else {
				facebookButton.Visibility = ViewStates.Invisible;
				twitterButton.Visibility = ViewStates.Invisible;
				signUpButton.Visibility = ViewStates.Invisible;
				signInButton.Visibility = ViewStates.Invisible;
			}

			// Social Login Examples
			facebookButton.Click += async delegate {
				LoginRadiusResponse res = await LoginRadiusSDK.SocialLogin ("facebook", this);
				Console.WriteLine (res.ToString ());
			};

			twitterButton.Click += async delegate {
				LoginRadiusResponse res = await LoginRadiusSDK.SocialLogin ("twitter", this);
				Console.WriteLine (res.ToString ());
			};

			// Registration Service examples
			signUpButton.Click += async delegate {
				LoginRadiusResponse res = await LoginRadiusSDK.RegistrationService (action: "registration", language: "", parent: this);
				Console.WriteLine (res.ToString());
			};

			signInButton.Click += async delegate {
				LoginRadiusResponse res = await LoginRadiusSDK.RegistrationService ("login", "", this);
				Console.WriteLine (res.ToString ());
			};

			// Logout Example
			logoutButton.Click += delegate {
				LoginRadiusSDK.Logout ();
				facebookButton.Visibility = ViewStates.Visible;
				twitterButton.Visibility = ViewStates.Visible;
				signUpButton.Visibility = ViewStates.Visible;
				signInButton.Visibility = ViewStates.Visible;
				logoutButton.Visibility = ViewStates.Invisible;
			};
		}

	}
}


