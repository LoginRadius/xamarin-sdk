using Refit;
using System;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.Authentication
{
    public class CheckUserNameAvailabilityAPI
        {
            public static async Task GetCheckUserNameAvailability(string apikey, string username, Action<LogiinRadiusExistsResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
            {
                var api = RestRequest.CallApi<ApiInterface>();

                try
                {
                    var response = await api.GetCheckUserNameAvailability(apikey, username);
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



