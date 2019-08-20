using System;
using System.Threading.Tasks;
using Refit;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.SocialLogin
{
    public class AccessTokenViaGoogleToken
    {
        public static async Task GetAccessTokenViaGoogleToken(string apikey, string google_access_token, Action<AccessTokenResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                var response = await api.GetAccessTokenViaGoogleToken(apikey, google_access_token);
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
