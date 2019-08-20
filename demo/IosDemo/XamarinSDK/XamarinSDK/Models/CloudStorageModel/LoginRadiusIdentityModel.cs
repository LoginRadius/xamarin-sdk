using XamarinSDK.Models.UserProfile;

namespace XamarinSDK.Models
{
    public class LoginRadiusIdentityModel : LoginRadiusTraditionalUserProfile
    {
        public string SignupDate { get; set; }
        public bool IsBlocked { get; set; }
    }
}
