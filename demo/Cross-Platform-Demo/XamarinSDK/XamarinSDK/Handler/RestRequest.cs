using Refit;
using System;

namespace XamarinSDK.Handler
{
    public class RestRequest
    {
        private static String API_V2_BASE_URL = "https://api.loginradius.com/";
        public static T CallApi<T>()
        {
            var api = RestService.For<T>(API_V2_BASE_URL);
            return api;
        }
    }
}
