using System;
using System.Collections.Generic;

namespace XamarinSDK.HybridWebView
{
    public class WebViewUrl
    {
        public string getWebUrlWithNoCallBack(Dictionary<string, string> myDictionary)
        {

            string appname = myDictionary["appname"];
            string apikey = myDictionary["apikey"];
            string callbackguid = myDictionary["callbackguid"];
            string provider = myDictionary["provider"].ToLower();

            // The root page of your application
            return "https://" + appname + ".hub.loginradius.com/RequestHandlor.aspx?apikey=" + apikey + "&provider=" + provider + "&is_access_token=true&ismobile=true&nocallback=true&callbackguid=" + callbackguid;

        }


        public string getWebUrl(Dictionary<string, string> myDictionary)
        {

            string appname = myDictionary["appname"];
            string apikey = myDictionary["apikey"];
            string provider = myDictionary["provider"].ToLower();

            // The root page of your application
            return "https://" + appname + ".hub.loginradius.com/RequestHandlor.aspx?apikey=" + apikey + "&provider=" + provider + "&is_access_token=true&ismobile=true";

        }
    }
}
