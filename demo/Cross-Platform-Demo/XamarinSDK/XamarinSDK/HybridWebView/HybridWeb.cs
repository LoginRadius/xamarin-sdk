using System.Collections.Generic;
using Xamarin.Forms;
namespace XamarinSDK.HybridWebView
{
    public class HybridWeb : Application
    {
        
       
       
        public HybridWeb(Dictionary<string, string> myDictionary)
        {
            
            string appname= myDictionary["appname"];
            string apikey = myDictionary["apikey"];
            string callbackguid = myDictionary["callbackguid"];
            string provider = myDictionary["provider"].ToLower();
            
            // The root page of your application
            MainPage = new NavigationPage(new Webview("https://"+appname+".hub.loginradius.com/RequestHandlor.aspx?apikey="+apikey+"&provider="+provider+ "&is_access_token=true&ismobile=true&nocallback=true&callbackguid="+ callbackguid));
           
        }

        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
           
        }
        
    }
}