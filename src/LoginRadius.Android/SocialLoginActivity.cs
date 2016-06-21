
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
        [Activity (Label = "SocialLoginActivity")]			
        public class SocialLoginActivity : Activity
        {
                private static WebView webView;

                public static LoginRadiusHandler handler;

                protected override void OnCreate (Bundle savedInstanceState)
                {
                        base.OnCreate (savedInstanceState);

                        SetContentView (LoginRadius.SDK.Resource.Layout.LR_WebView);
                        // Create your application here

                        string provider= Intent.GetStringExtra("provider");
                        string url = "https://" + LoginRadiusSDK.SiteName + ".hub.loginradius.com/RequestHandlor.aspx?apikey=" + LoginRadiusSDK.ApiKey + "&provider=" + provider + "&ismobile=1";

                        webView = (WebView)FindViewById (Resource.Id.rs_webview);
                        webView.SetWebViewClient (new SocialWebClient (this));
                        WebSettings settings = webView.Settings;
                        settings.JavaScriptEnabled = true;
                        webView.LoadUrl (url);
                }

                public void finishRegistration(bool success, string userProfile) 
                {
                        if (success) {
                                handler.onSuccess (userProfile);
                        } else {
                                handler.onFailure ("Social Logiun failure");
                        }
                        Finish ();
                }
        }

        public class SocialWebClient : WebViewClient
        {
                SocialLoginActivity activity;

                public SocialWebClient (SocialLoginActivity activity)
                {
                        this.activity = activity;
                }

                public override bool ShouldOverrideUrlLoading (WebView view, string url)
                {       
                        UriBuilder uri = new UriBuilder (url);

                        if (uri.ToString ().IndexOf ("token", StringComparison.Ordinal) != -1 && uri.Path.Equals ("/mobile.aspx")) {
                                NameValueCollection parameters = HttpUtility.ParseQueryString (url.Substring(url.IndexOf ("?", StringComparison.Ordinal)));
                                string token = parameters ["token"];

                                if (!String.IsNullOrEmpty (token)) {
                                        LoginRadiusSettings.LoginRadiusAccessToken = token;
                                        string userProfile = RestClient.Request (string.Format ("https://api.loginradius.com/api/v2/userprofile?access_token={0}", token), null, HttpMethod.GET);
					LoginRadiusSettings.LoginRadiusUserProfile = userProfile;
                                        this.finishRaaSAction (true, userProfile);
                                } else {
                                        this.finishRaaSAction (false, null);
                                }

                                return true;
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

