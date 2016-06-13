
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using Android.Net;

namespace LoginRadius.SDK
{
	[Activity (Label = "RegistrationServiceActivity")]
	public class RegistrationServiceActivity : Activity
	{
		private static WebView webView;

		public static LoginRadiusHandler handler;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (LoginRadius.SDK.Resource.Layout.LR_WebView);
			// Create your application here

			string serviceAction = Intent.GetStringExtra ("action");
			string language = Intent.GetStringExtra ("language");
			if (!String.IsNullOrEmpty (language)) {
				language = "-" + language;
			}

			string url = "https://cdn.loginradius.com/hub/prod/Theme/mobile" + language + "/index.html?apikey=" + LoginRadiusSDK.ApiKey + "&sitename=" + LoginRadiusSDK.SiteName + "&action=" + serviceAction;
			webView = (WebView)FindViewById (Resource.Id.rs_webview);
			webView.SetWebViewClient (new WebClient (this));
			WebSettings settings = webView.Settings;
			settings.JavaScriptEnabled = true;
			webView.LoadUrl (url);
		}

		public void finishRegistration (bool success, string userProfile)
		{
			if (success) {
				handler.onSuccess (userProfile);
			} else {
				handler.onFailure ("Registration service failure");
			}
			Finish ();
		}
	}


	public class WebClient : WebViewClient
	{
		RegistrationServiceActivity activity;

		public WebClient (RegistrationServiceActivity activity)
		{
			this.activity = activity;
		}

		public override bool ShouldOverrideUrlLoading (WebView view, string url)
		{
			NameValueCollection parameters = HttpUtility.ParseQueryString (url.Substring (url.IndexOf ("?")));
			string returnAction = parameters ["action"];
			string absString = url;

			if (!string.IsNullOrEmpty (returnAction)) {

				if (returnAction.Equals ("registration")) {
					if (absString.IndexOf ("status", StringComparison.Ordinal) != -1) {
						this.finishRaaSAction (true, null);
					}

				} else if (returnAction.Equals ("login")) {
					if (absString.IndexOf ("lrtoken", StringComparison.Ordinal) != -1) {
						string token = parameters ["lrtoken"];

						string userProfile = RestClient.Request (string.Format ("https://api.loginradius.com/api/v2/userprofile?access_token={0}", token), null, HttpMethod.GET);
						this.finishRaaSAction (true, userProfile);
					}

				} else if (returnAction.Equals ("forgotpassword")) {
					if (absString.IndexOf ("status", StringComparison.Ordinal) != -1) {
						this.finishRaaSAction (true, null);
					}

				} else if (returnAction.Equals ("sociallogin")) {
					if (absString.IndexOf ("lrtoken", StringComparison.Ordinal) != -1) {
						string token = parameters ["lrtoken"];
						string userProfile = RestClient.Request (string.Format ("https://api.loginradius.com/api/v2/userprofile?access_token={0}", token), null, HttpMethod.GET);
						this.finishRaaSAction (true, userProfile);
					}
				}
			}

			view.LoadUrl (url);
			return true;
		}

		public void finishRaaSAction (bool success, string userProfile)
		{
			this.activity.finishRegistration (success, userProfile);
		}
	}


}

