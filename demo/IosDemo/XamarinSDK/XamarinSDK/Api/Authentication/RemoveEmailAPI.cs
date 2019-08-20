using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.Authentication
{
    public class RemoveEmailAPI
    {
        public static async Task GetRemoveEmail(Dictionary<string, string> myDictionary, Action<LoginRadiusDeleteResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                String apikey = myDictionary["apikey"];
                String access_token = myDictionary["access_token"];
                String email = myDictionary["email"];
                JObject obj = new JObject();
                obj.Add("email", email);

                var response = await api.GetRemoveEmail(apikey, access_token,obj);
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
