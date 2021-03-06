﻿using Refit;
using System;
using System.Threading.Tasks;
using XamarinSDK.Handler;
using XamarinSDK.LoginRadiusException;
using XamarinSDK.Models;

namespace XamarinSDK.Api.Authentication
{
    public class ValidateAccesstokenAPI
    {
        public static async Task GetAccessTokenValidate(string apikey, string token, Action<AccessTokenResponse> OnSuccess = null, Action<ErrorResponse> OnFailure = null)
        {
            var api = RestRequest.CallApi<ApiInterface>();

            try
            {
                var response = await api.GetAccessTokenValidate(apikey, token);
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
