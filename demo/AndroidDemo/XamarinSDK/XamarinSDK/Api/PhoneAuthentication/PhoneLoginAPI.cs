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
    public class PhoneLoginAPI
    {
        public static async Task GetPhoneLogin(Dictionary<string, string> myDictionary, Action<LoginResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                String apikey = myDictionary["apikey"];
                String phone = myDictionary["phone"];
                String password = myDictionary["password"];
                String loginurl = "";
                String emailtemplate = "";
                String recaptcha = "";
                String securityanswer = "";
                if (myDictionary.ContainsKey("loginurl"))
                {
                    loginurl = myDictionary["loginurl"];
                }
                if (myDictionary.ContainsKey("emailtemplate"))
                {
                    emailtemplate = myDictionary["emailtemplate"];
                }
                if (myDictionary.ContainsKey("g-recaptcha-response"))
                {
                    recaptcha = myDictionary["g-recaptcha-response"];
                }
                if (myDictionary.ContainsKey("securityanswer"))
                {
                    recaptcha = myDictionary["securityanswer"];
                }

                JObject obj = new JObject();
                obj.Add("phone", phone);
                obj.Add("password", password);
                obj.Add("securityanswer", securityanswer);
                var response = await api.GetPhoneLogin(apikey,loginurl, emailtemplate, recaptcha,obj);
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
