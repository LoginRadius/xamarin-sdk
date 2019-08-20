using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models.Album;

namespace XamarinSDK.Api.SocialLogin
{
    public class AlbumAPI
    {
        public static async Task GetAlbum(string token, Action<List<LoginRadiusAlbum>> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                var response = await api.GetAlbum(token);
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
