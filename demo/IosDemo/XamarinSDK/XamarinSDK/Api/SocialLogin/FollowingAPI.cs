using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models.Following;

namespace XamarinSDK.Api.SocialLogin
{
    public class FollowingAPI
    {

        public static async Task GetFollowing(string token, Action<List<LoginRadiusFollowing>> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                var response = await api.GetFollowing(token);
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
