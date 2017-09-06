using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models.Video;

namespace XamarinSDK.Api.SocialLogin
{
   public class VideoAPI
    {
        public static async Task GetVideoData(string token,string nextcursor, Action<LoginRadiusVideo> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                var response = await api.GetVideo(token,nextcursor);
                if (OnSuccess != null) {
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

