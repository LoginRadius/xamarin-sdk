using Refit;
using System;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;
using XamarinSDK.Models.UserProfile;

namespace XamarinSDK.Api.Authentication
{
    public class UserRegistrationbyEmailAPI
    {
        public static async Task GetUserRegistrationbyEmail(string apikey, string sott, string verificationurl, string emailtemplate, UserIdentityCreateModel user,Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                var response = await api.GetUserRegistrationbyEmail(apikey,sott,verificationurl,emailtemplate,user);
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
