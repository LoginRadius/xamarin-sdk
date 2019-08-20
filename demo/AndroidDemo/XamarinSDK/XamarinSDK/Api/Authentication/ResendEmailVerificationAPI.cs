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
    public class ResendEmailVerificationAPI
    {

        public static async Task GetResendEmailVerification(Dictionary<string, string> myDictionary, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                String apikey = myDictionary["apikey"];
                String verificationurl = "";
                String emailtemplate = "";
                if (myDictionary.ContainsKey("verificationurl"))
                {
                    verificationurl = myDictionary["verificationurl"];
                }
                if (myDictionary.ContainsKey("emailtemplate"))
                {
                    emailtemplate = myDictionary["emailtemplate"];
                }
                String email = myDictionary["email"];
                JObject obj = new JObject();
                obj.Add("email", email);
               


                var response = await api.GetResendEmailVerification(apikey,verificationurl, emailtemplate, obj);
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
