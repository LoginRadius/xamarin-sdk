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

namespace XamarinSDK.Api.PhoneAuthentication
{
   public class PhoneLoginUsingOtpAPI
    {
        public static async Task GetPhoneLoginUsingOtp(Dictionary<string, string> myDictionary, Action<LoginResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                String apikey = myDictionary["apikey"];
                String phone = myDictionary["phone"];
                String otp = myDictionary["otp"];
                String smstemplate = "";
               
                if (myDictionary.ContainsKey("smstemplate"))
                {
                    smstemplate = myDictionary["smstemplate"];
                }
                JObject obj = new JObject();
                obj.Add("phone", phone);
                obj.Add("otp", otp);
                var response = await api.GetPhoneLoginUsingOtp(apikey,smstemplate,obj);
                if (OnSuccess != null)
                {
                    OnSuccess(response);
                }
            }
            catch (ApiException ex)
            {
                var statusCode = ex.StatusCode;
                var error = ex.GetContentAs<ErrorResponse>();
                error.description.ToString();
                if (OnFailure != null) { }
                OnFailure(error);
            }


        }
    }
}
