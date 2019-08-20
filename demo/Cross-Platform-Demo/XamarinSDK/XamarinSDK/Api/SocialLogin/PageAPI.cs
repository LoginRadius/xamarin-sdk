using Refit;
using System;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models.Page;

namespace XamarinSDK.Api.SocialLogin
{
    public class PageAPI
    {
        public static async Task GetPage(string token, string pagename, Action<LoginRadiusPage> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                var response = await api.GetPage(token, pagename);
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
