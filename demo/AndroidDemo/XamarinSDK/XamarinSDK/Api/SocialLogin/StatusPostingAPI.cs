using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.SocialLogin
{
  public  class StatusPostingAPI
    {
        public static async Task GetStatusPosting(string token,PostStatus poststatus, Action<LoginRadiusPostResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();
            try
            {
                var response = await api.GetStatusPosting(token,poststatus.Description,poststatus.Caption,poststatus.Status,poststatus.Imageurl,poststatus.Url,poststatus.Title);
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

