using LoginRadiusSDK.V2.Models.Password;
using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSDK.Models;
using XamarinSDK.Models.Album;
using XamarinSDK.Models.Audio;
using XamarinSDK.Models.CheckIn;
using XamarinSDK.Models.Company;
using XamarinSDK.Models.Contact;
using XamarinSDK.Models.CustomerAuthentication.Phone;
using XamarinSDK.Models.Event;
using XamarinSDK.Models.Following;
using XamarinSDK.Models.Group;
using XamarinSDK.Models.Like;
using XamarinSDK.Models.Mention;
using XamarinSDK.Models.Page;
using XamarinSDK.Models.Photo;
using XamarinSDK.Models.UserProfile;
using XamarinSDK.Models.Video;

namespace XamarinSDK.Handler
{
  public interface ApiInterface
    {

        /**
        * Authentication APIs
        * 
        * */

        [Get("/api/v2/userprofile")]
        Task<LoginRadiusTraditionalUserProfile> GetUserProfile([AliasAs("access_token")]string access_token);

        [Get("/api/v2/video")]
        Task<LoginRadiusVideo> GetVideo([AliasAs("access_token")]string access_token, [AliasAs("nextcursor")]string nextcursor);

        [Post("/api/v2/status")]
        Task<LoginRadiusPostResponse> GetStatusPosting([AliasAs("access_token")]string access_token, [AliasAs("description")]string description, [AliasAs("caption")]string caption, [AliasAs("status")]string status, [AliasAs("imageurl")]string imageurl, [AliasAs("url")]string url, [AliasAs("title")]string title);

        [Get("/api/v2/status")]
        Task<List<LoginRadiusStatus>> GetStatus([AliasAs("access_token")]string access_token);

        [Get("/api/v2/post")]
        Task<List<LoginRadiusPost>> GetPost([AliasAs("access_token")]string access_token);

        [Get("/api/v2/photo")]
        Task<List<LoginRadiusPhoto>> GetPhoto([AliasAs("access_token")]string access_token, [AliasAs("albumid")]string albumid);

        [Get("/api/v2/page")]
        Task<LoginRadiusPage> GetPage([AliasAs("access_token")]string access_token, [AliasAs("pagename")]string pagename);

        [Post("/api/v2/message")]
        Task<LoginRadiusPostResponse> GetMessage([AliasAs("access_token")]string access_token, [AliasAs("to")]string to, [AliasAs("subject")]string subject, [AliasAs("message")]string message);

        [Get("/api/v2/mention")]
        Task<List<LoginRadiusMention>> GetMention([AliasAs("access_token")]string access_token);

        [Get("/api/v2/like")]
        Task<List<LoginRadiusLike>> GetLike([AliasAs("access_token")]string access_token);

        [Get("/api/v2/group")]
        Task<List<LoginRadiusGroup>> GetGroup([AliasAs("access_token")]string access_token);

        [Get("/api/v2/following")]
        Task<List<LoginRadiusFollowing>> GetFollowing([AliasAs("access_token")]string access_token);

        [Get("/api/v2/event")]
        Task<List<LoginRadiusEvent>> GetEvent([AliasAs("access_token")]string access_token);

        [Get("/api/v2/contact")]
        Task<LoginRadiusContact> GetContact([AliasAs("access_token")]string access_token, [AliasAs("nextcursor")]int nextcursor);

        [Get("/api/v2/company")]
        Task<List<LoginRadiusCompany>> GetCompany([AliasAs("access_token")]string access_token);

        [Get("/api/v2/checkin")]
        Task<List<LoginRadiusCheckIn>> GetCheckIn([AliasAs("access_token")]string access_token);

        [Get("/api/v2/audio")]
        Task<List<LoginRadiusAudio>> GetAudio([AliasAs("access_token")]string access_token);

        [Get("/api/v2/album")]
        Task<List<LoginRadiusAlbum>> GetAlbum([AliasAs("access_token")]string access_token);

        [Get("/identity/v2/auth/access_token/invalidate")]
        Task<LoginRadiusPostResponse> GetAccessTokenInvalidate([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token);

        [Get("/identity/v2/auth/access_token/validate")]
        Task<AccessTokenResponse> GetAccessTokenValidate([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token);

        [Get("/identity/v2/auth/email")]
        Task<LogiinRadiusExistsResponse> GetCheckEmailAvailability([AliasAs("apikey")]string apikey, [AliasAs("email")]string email);

        [Get("/identity/v2/auth/username")]
        Task<LogiinRadiusExistsResponse> GetCheckUserNameAvailability([AliasAs("apikey")]string apikey, [AliasAs("username")]string username);
  
        [Get("/identity/v2/auth/account")]
        Task<LoginRadiusIdentity> GetReadAllProfiles([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token);

        [Get("/identity/v2/auth/email")]
        Task<LoginRadiusPostResponse<LoginResponse>> GetVerifyEmail([AliasAs("apikey")]string apikey, [AliasAs("verificationtoken")]string verificationtoken, [AliasAs("url")]string url);

        [Get("/identity/v2/auth/socialidentity")]
        Task<LoginRadiusIdentity> GetSocialIdentity([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token);

        [Post("/identity/v2/auth/login")]
        Task<LoginResponse> GetLoginbyEmail([AliasAs("apikey")]string apikey,[AliasAs("verificationurl")]string verificationurl, [AliasAs("loginurl")]string loginurl, [AliasAs("emailtemplate")]string emailtemplate, [AliasAs("g-recaptcha-response")]string recaptcha, [Body]  JObject obj);

        [Post("/identity/v2/auth/login")]
        Task<LoginResponse> GetLoginbyUserName([AliasAs("apikey")]string apikey, [AliasAs("verificationurl")]string verificationurl, [AliasAs("loginurl")]string loginurl, [AliasAs("emailtemplate")]string emailtemplate, [AliasAs("g-recaptcha-response")]string recaptcha, [Body]  JObject obj);

        [Post("/identity/v2/auth/register")]
        Task<LoginRadiusPostResponse> GetUserRegistrationbyEmail([AliasAs("apikey")]string apikey,[AliasAs("sott")]string sott, [AliasAs("verificationurl")]string verificationurl, [AliasAs("emailtemplate")]string emailtemplate,[Body] UserIdentityCreateModel user);

        [Post("/identity/v2/auth/password")]
        Task<LoginRadiusPostResponse> GetForgotPassword([AliasAs("apikey")]string apikey,[AliasAs("resetpasswordurl")]string resetpasswordurl, [AliasAs("emailtemplate")]string emailtemplate, [Body]  JObject obj);

        [Post("/identity/v2/auth/email")]
        Task<LoginRadiusPostResponse> GetAddEmail([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [AliasAs("emailtemplate")]string emailtemplate, [AliasAs("verificationurl")]string verificationurl, [Body]  JObject obj);

        [Put("/identity/v2/auth/password")]
        Task<LoginRadiusPostResponse> GetChangePassword([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [Body]  JObject obj);

        [Put("/identity/v2/auth/socialidentity")]
        Task<LoginRadiusPostResponse> GetLinkSocialIdentities([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [Body]  JObject obj);

        [Put("/identity/v2/auth/register")]
        Task<LoginRadiusPostResponse> GetResendEmailVerification([AliasAs("apikey")]string apikey, [AliasAs("verificationurl")]string verificationurl, [AliasAs("emailtemplate")]string emailtemplate, [Body]  JObject obj);

        [Put("/identity/v2/auth/password")]
        Task<LoginRadiusPostResponse> GetResetPasswordbyResetToken([AliasAs("apikey")]string apikey, [Body]  JObject obj);

        [Put("/identity/v2/auth/password/securityanswer")]
        Task<LoginRadiusPostResponse> GetResetPasswordbySecurityQuestion([AliasAs("apikey")]string apikey, [Body]  ResetPasswordBySecurityAnswerModel obj);

        [Put("/identity/v2/auth/username")]
        Task<LoginRadiusPostResponse> GetChangeUserName([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [Body]  JObject obj);

        [Put("/identity/v2/auth/account")]
        Task<LoginRadiusPostResponse> GetUpdateProfilebyToken([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [AliasAs("verificationurl")]string verificationurl, [AliasAs("emailtemplate")]string emailtemplate, [AliasAs("smstemplate")]string smstemplate, [Body]  UserIdentityCreateModel obj);

        [Put("/identity/v2/auth/account")]
        Task<LoginRadiusPostResponse> GetUpdateSecurityQuestionbyAccess_token([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [Body]  ResetPasswordBySecurityAnswerModel obj);

        [Delete("/identity/v2/auth/account")]
        Task<DeleteRequestAcceptedResponse> GetDeleteAccount([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token,[AliasAs("deleteurl")]string deleteurl, [AliasAs("emailtemplate")]string emailtemplate);

        [Delete("/identity/v2/auth/email")]
        Task<LoginRadiusDeleteResponse> GetRemoveEmail([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token,[Body]  JObject obj);

        [Delete("/identity/v2/auth/socialidentity")]
        Task<LoginRadiusDeleteResponse> GetUnlinkSocialIdentities([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [Body]  JObject obj);



        /**
        * Phone Number Login APIs
        * 
        * */

        [Post("/identity/v2/auth/login")]
        Task<LoginResponse> GetPhoneLogin([AliasAs("apikey")]string apikey, [AliasAs("loginurl")]string loginurl, [AliasAs("smstemplate")]string smstemplate, [AliasAs("g-recaptcha-response")]string recaptcha, [Body]  JObject obj);

        [Post("/identity/v2/auth/login")]
        Task<LoginResponse> GetPhoneLoginUsingOtp([AliasAs("apikey")]string apikey, [AliasAs("smstemplate")]string smstemplate, [Body]  JObject obj);

        [Get("/identity/v2/auth/phone")]
        Task<LogiinRadiusExistsResponse> GetPhoneNumberAvailability([AliasAs("apikey")]string apikey, [AliasAs("phone")]string phone);

        [Get("/identity/v2/auth/login/otp")]
        Task<PhoneSendOtpModel> GetPhoneSendOtp([AliasAs("apikey")]string apikey, [AliasAs("phone")]string phone, [AliasAs("smstemplate")]string smstemplate);

        [Post("/identity/v2/auth/password/otp")]
        Task<UpdatePhoneResponse> GetPhoneForgotPasswordbyOtp([AliasAs("apikey")]string apikey, [AliasAs("smstemplate")]string smstemplate, [Body]  JObject obj);

        [Post("/identity/v2/auth/phone/otp")]
        Task<UpdatePhoneResponse> GetPhoneResendVerificationOtp([AliasAs("apikey")]string apikey, [AliasAs("smstemplate")]string smstemplate, [Body]  JObject obj);

        [Post("/identity/v2/auth/phone/otp")]
        Task<LoginRadiusPostResponse> GetPhoneResendVerificationOtpbyToken([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [AliasAs("smstemplate")]string smstemplate, [Body]  JObject obj);

        [Post("/identity/v2/auth/register")]
        Task<LoginRadiusPostResponse> GetPhoneUserRegistration([AliasAs("apikey")]string apikey, [AliasAs("sott")]string sott, [AliasAs("smstemplate")]string smstemplate, [AliasAs("verificationurl")]string verificationurl, [Body] UserIdentityCreateModel obj);

        [Put("/identity/v2/auth/phone")]
        Task<UpdatePhoneResponse> GetPhoneNumberUpdate([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [AliasAs("smstemplate")]string smstemplate,[Body]  JObject obj);

        [Put("/identity/v2/auth/password/otp")]
        Task<LoginRadiusPostResponse> GetPhoneResetPasswordbyOtp([AliasAs("apikey")]string apikey,[AliasAs("smstemplate")]string smstemplate, [Body]  JObject obj);

        [Put("/identity/v2/auth/phone/otp")]
        Task<LoginResponse> GetPhoneVerificationbyOtp([AliasAs("apikey")]string apikey, [AliasAs("otp")]string otp, [AliasAs("smstemplate")]string smstemplate, [Body]  JObject obj);

        [Put("/identity/v2/auth/phone/otp")]
        Task<LoginRadiusPostResponse> GetPhoneVerificationOtpbyToken([AliasAs("apikey")]string apikey, [AliasAs("access_token")]string access_token, [AliasAs("otp")]string otp, [AliasAs("smstemplate")]string smstemplate);


        /**
       * One-Click Authentication APIs
       * 
       * */

        [Get("/identity/v2/auth/login/oneclicksignin")]
        Task<LoginRadiusPostResponse> GetOneClickSigninByEmail([AliasAs("apikey")]string apikey, [AliasAs("email")]string email, [AliasAs("oneclicksignintemplate")]string oneclicksignintemplate, [AliasAs("verificationurl")]string verificationurl);

        [Get("/identity/v2/auth/login/oneclicksignin")]
        Task<LoginRadiusPostResponse> GetOneClickSigninByUserName([AliasAs("apikey")]string apikey, [AliasAs("username")]string username, [AliasAs("oneclicksignintemplate")]string oneclicksignintemplate, [AliasAs("verificationurl")]string verificationurl);

        [Get("/identity/v2/auth/login/oneclickverify")]
        Task<LoginResponse> GetOneClickSigninVerification([AliasAs("apikey")]string apikey, [AliasAs("verificationtoken")]string verificationtoken, [AliasAs("welcomeemailtemplate")]string welcomeemailtemplate);


        /**
      * Email Prompt AutoLogin APIs
      * 
      * */

        [Get("/identity/v2/auth/login/autologin")]
        Task<LoginRadiusPostResponse> GetEmailPromptAutoLoginByEmail([AliasAs("apikey")]string apikey, [AliasAs("email")]string email, [AliasAs("clientguid")]string clientguid, [AliasAs("autologinemailtemplate")]string autologinemailtemplate, [AliasAs("welcomeemailtemplate")]string welcomeemailtemplate, [AliasAs("redirecturl")]string redirecturl);

        [Get("/identity/v2/auth/login/autologin")]
        Task<LoginRadiusPostResponse> GetEmailPromptAutoLoginByUsername([AliasAs("apikey")]string apikey, [AliasAs("username")]string username, [AliasAs("clientguid")]string clientguid, [AliasAs("autologinemailtemplate")]string autologinemailtemplate, [AliasAs("welcomeemailtemplate")]string welcomeemailtemplate, [AliasAs("redirecturl")]string redirecturl);

        [Get("/identity/v2/auth/login/autologin/ping")]
        Task<LoginResponse> GetEmailPromptAutoLoginPing([AliasAs("apikey")]string apikey, [AliasAs("clientguid")]string clientguid);

    }


}
