using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models.UserProfile;

namespace XamarinSDK.Api.Authentication
{
   public class ReadAllProfilesAPI
    {
        public static async Task GetReadAllProfiles(string apikey, string token, Action<LoginRadiusIdentity> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                var response = await api.GetReadAllProfiles(apikey,token);
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
