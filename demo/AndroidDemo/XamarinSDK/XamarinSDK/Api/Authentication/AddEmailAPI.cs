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

namespace XamarinSDK.Api.Authentication
{
   public class AddEmailAPI
    {
        public static async Task GetAddEmail(Dictionary<string, string> myDictionary, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                String apikey = myDictionary["apikey"];
                String access_token = myDictionary["access_token"];
                String email = myDictionary["email"];
                String type = myDictionary["type"];
                JObject obj = new JObject();
                obj.Add("email", email);
                obj.Add("type", type);
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

                var response = await api.GetAddEmail(apikey,access_token, emailtemplate,verificationurl,obj);
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
