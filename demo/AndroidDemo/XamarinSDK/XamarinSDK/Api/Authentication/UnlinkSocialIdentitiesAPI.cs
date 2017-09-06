using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.Authentication
{
  public class UnlinkSocialIdentitiesAPI
    {
        public static async Task GetUnlinkSocialIdentities(Dictionary<string, string> myDictionary, Action<LoginRadiusDeleteResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                String apikey = myDictionary["apikey"];
                String access_token = myDictionary["access_token"];
                String provider = myDictionary["provider"];
                String providerid = myDictionary["providerid"];
                JObject obj = new JObject();
                obj.Add("provider", provider);
                obj.Add("providerid", providerid);

                var response = await api.GetUnlinkSocialIdentities(apikey,access_token, obj);
                if (OnSuccess != null)
                {
                    OnSuccess(response);
                }
            }
            catch (ApiException ex)
            {
                var statusCode = ex.StatusCode;
                var error = ex.GetContentAs<ErrorResponse>();
                if (OnFailure != null) { }
                OnFailure(error);
            }


        }
    }
}
