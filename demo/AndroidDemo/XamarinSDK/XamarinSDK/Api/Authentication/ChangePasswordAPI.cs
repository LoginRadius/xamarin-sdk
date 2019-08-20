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
    public class ChangePasswordAPI
    {
        public static async Task GetChangePassword(Dictionary<string, string> myDictionary, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                String apikey = myDictionary["apikey"];
                String access_token = myDictionary["access_token"];
                String oldpassword = myDictionary["oldpassword"];
                String newpassword = myDictionary["newpassword"];
                JObject obj = new JObject();
                obj.Add("oldpassword", oldpassword);
                obj.Add("newpassword", newpassword);


                var response = await api.GetChangePassword(apikey, access_token,obj);
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
