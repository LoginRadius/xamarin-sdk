using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.One_Click_Authentication
{
   public class OneClickSigninByVerificationAPI
    {
        public static async Task GetOneClickSigninVerification(Dictionary<string, string> myDictionary, Action<LoginResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                String apikey = myDictionary["apikey"];
                String verificationtoken = myDictionary["verificationtoken"];
                String welcomeemailtemplate = "";
              
                if (myDictionary.ContainsKey("welcomeemailtemplate"))
                {
                    welcomeemailtemplate = myDictionary["welcomeemailtemplate"];
                }
                
                var response = await api.GetOneClickSigninVerification(apikey, verificationtoken, welcomeemailtemplate);
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
