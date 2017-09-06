using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;
using XamarinSDK.Models.UserProfile;

namespace XamarinSDK.Api.Authentication
{
   public class UpdateProfilebyTokenAPI
    {
        public static async Task GetUpdateProfilebyToken(Dictionary<string, string> myDictionary, UserIdentityCreateModel obj, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                String apikey = myDictionary["apikey"];
                String access_token = myDictionary["access_token"];
                String verificationurl = "";
                String emailtemplate = "";
                String smstemplate = "";
                if (myDictionary.ContainsKey("verificationurl"))
                {
                    verificationurl = myDictionary["verificationurl"];
                }
                if (myDictionary.ContainsKey("emailtemplate"))
                {
                    emailtemplate = myDictionary["emailtemplate"];
                }
                if (myDictionary.ContainsKey("smstemplate"))
                {
                    smstemplate = myDictionary["smstemplate"];
                }

                var response = await api.GetUpdateProfilebyToken(apikey, access_token, verificationurl,emailtemplate, smstemplate, obj);
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
