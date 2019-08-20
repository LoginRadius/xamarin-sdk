using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.PhoneAuthentication
{
    public class PhoneResendVerificationOtpbyTokenAPI
    {
        public static async Task GetPhoneResendVerificationOtpbyToken(Dictionary<string, string> myDictionary, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                String apikey = myDictionary["apikey"];
                String access_token = myDictionary["access_token"];
                String phone = myDictionary["phone"];
                String smstemplate = "";
                JObject obj = new JObject();
                obj.Add("phone", phone);

                if (myDictionary.ContainsKey("smstemplate"))
                {
                    smstemplate = myDictionary["smstemplate"];
                }
                var response = await api.GetPhoneResendVerificationOtpbyToken(apikey, access_token,smstemplate,obj);
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
