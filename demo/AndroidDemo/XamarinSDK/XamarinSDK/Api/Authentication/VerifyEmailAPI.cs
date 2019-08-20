using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.Authentication
{
    public class VerifyEmailAPI
    {
        public static async Task GetVerifyEmail(Dictionary<string, string> myDictionary, Action<LoginRadiusPostResponse<LoginResponse>> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                String apikey = myDictionary["apikey"];
                String verificationtoken = myDictionary["verificationtoken"];
               
                String url = "";
               
                if (myDictionary.ContainsKey("url"))
                {
                    url = myDictionary["url"];
                }
               
                var response = await api.GetVerifyEmail(apikey,verificationtoken,url);
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
