using System.Collections.Generic;


namespace LoginRadiusSDK.V2.Models.Password
{
    public class ResetPasswordBySecurityAnswerModel 
    {
        public Dictionary<string, string> SecurityAnswer { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}