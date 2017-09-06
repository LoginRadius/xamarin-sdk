using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models.CustomerAuthentication.Phone;

namespace XamarinSDK.Api.PhoneAuthentication
{
   public class PhoneNumberUpdateAPI
    {
        public static async Task GetPhoneNumberUpdate(Dictionary<string, string> myDictionary, Action<UpdatePhoneResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
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
                var response = await api.GetPhoneNumberUpdate(apikey,access_token,smstemplate,obj);
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
