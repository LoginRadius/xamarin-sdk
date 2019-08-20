using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;
using XamarinSDK.Models.UserProfile;

namespace XamarinSDK.Api.PhoneAuthentication
{
    public  class PhoneUserRegistrationAPI
    {
        public static async Task GetPhoneUserRegistration(Dictionary<string, string> myDictionary, UserIdentityCreateModel user, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                String apikey = myDictionary["apikey"];
                String sott = myDictionary["sott"];
                String verificationurl = "";
                String smstemplate = "";

                if (myDictionary.ContainsKey("verificationurl"))
                {
                    verificationurl = myDictionary["verificationurl"];
                }
                if (myDictionary.ContainsKey("smstemplate"))
                {
                    smstemplate = myDictionary["smstemplate"];
                }
                var response = await api.GetPhoneUserRegistration(apikey,sott,verificationurl,smstemplate,user);
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
