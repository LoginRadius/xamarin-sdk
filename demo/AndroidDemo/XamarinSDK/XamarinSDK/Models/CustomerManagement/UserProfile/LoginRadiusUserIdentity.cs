using System.Collections.Generic;


namespace XamarinSDK.Models.UserProfile
{
    public class LoginRadiusIdentity : LoginRadiusTraditionalUserProfile
    {
        public List<LoginRadiusSocialUserProfile> Identities { get; set; }

    }
}