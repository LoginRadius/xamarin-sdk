using System;
using System.Collections.Generic;

namespace XamarinSDK.Models.UserProfile
{
    public class LoginRadiusTraditionalUserProfile : LoginRadiusSocialUserProfile
    {
        public string Password { get; set; }

        public DateTime? LastPasswordChangeDate { get; set; }

        public DateTime? PasswordExpirationDate { get; set; }

        public string LastPasswordChangeToken { get; set; }

        public bool? EmailVerified { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public string Uid { get; set; }

        public Dictionary<string, string> CustomFields { get; set; }

        public bool? IsEmailSubscribed { get; set; }

        public string UserName { get; set; }

        public int? NoOfLogins { get; set; }

        public List<string> PreviousUids { get; set; }

        public string PhoneId { get; set; }

        public bool? PhoneIdVerified { get; set; }

        public string ExternalUserLoginId { get; set; }

        public string RegistrationProvider { get; set; }

        public bool? IsLoginLocked { get; set; }

        public string LoginLockedType { get; set; }

        public string LastLoginLocation { get; set; }

        public string RegistrationSource { get; set; }

        public bool? IsCustomUid { get; set; }

        public List<LoginRadiusEmail> UnverifiedEmail { get; set; }
    }
}
