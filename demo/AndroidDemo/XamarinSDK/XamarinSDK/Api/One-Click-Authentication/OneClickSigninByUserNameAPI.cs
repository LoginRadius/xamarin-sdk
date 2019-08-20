using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.One_Click_Authentication
{
    public class OneClickSigninByUserNameAPI
    {
        public static async Task GetOneClickSigninByUserName(Dictionary<string, string> myDictionary, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                String apikey = myDictionary["apikey"];
                String username = myDictionary["username"];
                String oneclicksignintemplate = "";
                String verificationurl = "";

                if (myDictionary.ContainsKey("oneclicksignintemplate"))
                {
                    oneclicksignintemplate = myDictionary["oneclicksignintemplate"];
                }
                if (myDictionary.ContainsKey("verificationurl"))
                {
                    verificationurl = myDictionary["verificationurl"];
                }
                var response = await api.GetOneClickSigninByUserName(apikey, username, oneclicksignintemplate, verificationurl);
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
