using LoginRadiusSDK.V2.Models.Password;
using Refit;
using System;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.Authentication
{
    public class UpdateSecurityQuestionbyAccess_tokenAPI
    {
        public static async Task GetUpdateSecurityQuestionbyAccess_token(string apikey, string access_token, ResetPasswordBySecurityAnswerModel obj, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                var response = await api.GetUpdateSecurityQuestionbyAccess_token(apikey, access_token, obj);
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
