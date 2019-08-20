using XamarinSDK.Models.UserProfile;

namespace XamarinSDK.Models
{
    public class LoginResponse
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public LoginRadiusTraditionalUserProfile Profile { get; set; }
    }
}
