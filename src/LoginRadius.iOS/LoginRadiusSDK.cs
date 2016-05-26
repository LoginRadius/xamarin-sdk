using System;

namespace LoginRadius.iOS
{
        public partial class LoginRadiusSDK
        {
                public static string ApiKey { get; set; }

                public static string SiteName { get; set; }


                public LoginRadiusSDK (string apiKey, string siteName)
                {
                        ApiKey = apiKey;
                        SiteName = siteName;
                }
			
        }
}

