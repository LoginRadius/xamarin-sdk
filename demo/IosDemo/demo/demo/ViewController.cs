using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using XamarinSDK.HybridWebView;
using XamarinSDK.Api.EmailPromptAutoLogin;
using SafariServices;
using XamarinSDK.Api.Authentication;
using System.Diagnostics;

namespace demo
{
    public partial class ViewController : UIViewController
    {

        string apiKey = "<put your apikey>";
        string appName = "<put your sitename>";
        public ViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           
           
            // Perform any additional setup after loading the view, typically from a nib.
        }



        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void Facebook_TouchUpInside(UIButton sender)
        {

            // GetEmailPromptAutoLoginPing(apikey, guid.GUIDTOKEN);
            GUIDStorage guid = new GUIDStorage();
            Guid obj = Guid.NewGuid();
            guid.GUIDTOKEN = Convert.ToString(obj);

            var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
            // appDelegate.FinishedLaunching();
            Dictionary<string, string> webview = new Dictionary<string, string>();
            webview.Add("appname", this.appName);
            webview.Add("callbackguid", guid.GUIDTOKEN);
            webview.Add("apikey", this.apiKey);
            webview.Add("provider", "facebook");
            WebViewUrl web = new WebViewUrl();
            var sfvc = new SFSafariViewController(new NSUrl(web.getWebUrlWithNoCallBack(webview)), true);
            PresentViewController(sfvc, true, null);
            // for this api call for no callback function if you need to social login the you need to add a nocallback feture form loginradius backend.
            GetEmailPromptAutoLoginPing(this.apiKey, guid.GUIDTOKEN);

        }

        partial void Google_TouchUpInside(UIButton sender)
        {
            GUIDStorage guid = new GUIDStorage();
            Guid obj = Guid.NewGuid();
            guid.GUIDTOKEN = Convert.ToString(obj);

            var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
            // appDelegate.FinishedLaunching();
            Dictionary<string, string> webview = new Dictionary<string, string>();
            webview.Add("appname", this.appName);
            webview.Add("callbackguid", guid.GUIDTOKEN);
            webview.Add("apikey", this.apiKey);
            webview.Add("provider", "google");
            WebViewUrl web = new WebViewUrl();
            var sfvc = new SFSafariViewController(new NSUrl(web.getWebUrlWithNoCallBack(webview)), true);
            PresentViewController(sfvc, true, null);
            GetEmailPromptAutoLoginPing(this.apiKey, guid.GUIDTOKEN);
        }

        


        public async void GetLoginByEmail(string email, string password)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("apikey", this.apiKey);
            data.Add("email", email);
            data.Add("password", password);

            await LoginbyEmailAPI.GetLoginbyEmail(data, res => {

                Debug.Write("access_token", res.access_token);

            }, (error) => {

                Debug.Write("error", error.description);

            });
        }

        public async void GetEmailPromptAutoLoginPing(string apikey, string clientguid)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("apikey", apikey);
            data.Add("clientguid", clientguid);
            await EmailPromptAutoLoginPingAPI.GetEmailPromptAutoLoginPing(data, response =>
            {

                 Debug.Write("access_token", response.access_token);
                 DismissViewController(true, null);
                GetReadAllProfiles(this.apiKey, response.access_token);

            }, (error) =>
            {

                GetEmailPromptAutoLoginPing(apikey, clientguid);

            });


        }


        public async void GetReadAllProfiles(string apikey, string access_token)
        {
            await ReadAllProfilesAPI.GetReadAllProfiles(apikey, access_token, response => {
                Debug.Write("error", response.FirstName);

            }, (error) => {
                Debug.Write("error", error.description);
            });
        }


    }

}