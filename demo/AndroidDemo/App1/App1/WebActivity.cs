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
using XamarinSDK.HybridWebView;
using System.Threading.Tasks;
using XamarinSDK.Models;
using XamarinSDK.Api.EmailPromptAutoLogin;

namespace App1
{
    [Activity(Label = "WebActivity")]
    public class WebActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        Guid obj = Guid.NewGuid();
        GUIDStorage guid = new GUIDStorage();
       
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
             string apikey = Intent.GetStringExtra("apikey") ?? "";
            string appname = Intent.GetStringExtra("appname") ?? "";
            string provider = Intent.GetStringExtra("provider") ?? "";
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.SetTitleBarVisibility(Xamarin.Forms.AndroidTitleBarVisibility.Never);
            guid.GUIDTOKEN = Convert.ToString(obj);
            Dictionary<string, string> webview = new Dictionary<string, string>();
            webview.Add("appname", appname);
            webview.Add("callbackguid", guid.GUIDTOKEN);
            webview.Add("apikey", apikey);
            webview.Add("provider", provider);
            GetEmailPromptAutoLoginPing(apikey, guid.GUIDTOKEN);
           
                 
            LoadApplication(new HybridWeb(webview));
        }

        public async void GetEmailPromptAutoLoginPing(string apikey, string clientguid)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("apikey", apikey);
            data.Add("clientguid", clientguid);
            await EmailPromptAutoLoginPingAPI.GetEmailPromptAutoLoginPing(data, response =>
            {
                var activity2 = new Intent(this, typeof(ProfileActivity));
                activity2.PutExtra("access_token", response.access_token);
                StartActivity(activity2);


            }, (error) =>
            {

                GetEmailPromptAutoLoginPing(apikey, guid.GUIDTOKEN);

            });
           

        }
    }
}