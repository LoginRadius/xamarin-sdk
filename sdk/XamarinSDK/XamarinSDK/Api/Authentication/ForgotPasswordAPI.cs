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
   public class ForgotPasswordAPI
    {
        public static async Task GetForgotPassword(Dictionary<string, string> myDictionary, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                String apikey = myDictionary["apikey"];
                String resetpasswordurl = myDictionary["resetpasswordurl"];
                String email = myDictionary["email"];
                JObject obj = new JObject();
                obj.Add("email",email);
                String emailtemplate = "";

                if (myDictionary.ContainsKey("emailtemplate"))
                {
                    emailtemplate = myDictionary["emailtemplate"];
                }

                var response = await api.GetForgotPassword(apikey,resetpasswordurl,emailtemplate,obj);
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
