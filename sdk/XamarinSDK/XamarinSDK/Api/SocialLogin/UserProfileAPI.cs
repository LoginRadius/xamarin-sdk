using Refit;
using System;
using System.Threading.Tasks;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Handler;
using XamarinSDK.Models.UserProfile;

namespace XamarinSDK.Api.UserProfileAPI
{
   public class UserProfileAPI
    {

        public static async Task GetUserProfile(string token, Action<LoginRadiusTraditionalUserProfile> OnSuccess=null, Action<ErrorResponse> OnFailure=null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                var response = await api.GetUserProfile(token);
                if (OnSuccess != null)
                {
                    OnSuccess(response);
                }
            }
            catch (ApiException ex)  {
                var statusCode = ex.StatusCode;
                var error = ex.GetContentAs<ErrorResponse>();
                error.description.ToString();
                if (OnFailure != null) { }
                OnFailure(error);
            }
        
              
            }


        }

      
    
}
