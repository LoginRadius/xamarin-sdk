using System.Collections.Generic;


namespace XamarinSDK.Models
{
    public class LoginRadiusAccountRolesResponse
    {
        public List<string> Data { get; set; }
        public bool SignIn { get; set; }
    }

    public class LoginRadiusAccountRolesUpsert
    {
        public List<string> Roles { get; set; }
    }

}
