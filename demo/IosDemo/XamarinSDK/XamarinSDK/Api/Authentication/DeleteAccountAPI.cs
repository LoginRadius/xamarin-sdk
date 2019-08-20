using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.Authentication
{
    public class DeleteAccountAPI
    {
        public static async Task GetDeleteAccount(Dictionary<string, string> myDictionary, Action<DeleteRequestAcceptedResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {

                String apikey = myDictionary["apikey"];
                String access_token = myDictionary["access_token"];
                String deleteurl = "";
                String emailtemplate = "";

                if (myDictionary.ContainsKey("deleteurl"))
                {
                    deleteurl = myDictionary["deleteurl"];
                }
                if (myDictionary.ContainsKey("emailtemplate"))
                {
                    emailtemplate = myDictionary["emailtemplate"];
                }

                var response = await api.GetDeleteAccount(apikey,access_token,deleteurl,emailtemplate);
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
