using System.Threading.Tasks;
using UIKit;
using Foundation;

namespace LoginRadius.SDK
{
	public partial class LoginRadiusSDK
        {
                public static Task<LoginRadiusResponse> RegistrationService (string action, string language, UIViewController parent)
                {
                        var rsCompletion = new TaskCompletionSource<LoginRadiusResponse> ();
			LoginRadiusHandler handler = new LoginRadiusHandler (rsCompletion, action);

			RegistrationServiceViewController rvc = new RegistrationServiceViewController (action, language, handler);
                        UINavigationController navVC = new UINavigationController (rvc);

                        parent.PresentViewController (navVC, false, null);

                        return rsCompletion.Task;
                }

                public static Task<LoginRadiusResponse> SocialLogin (string provider, UIViewController parent)
                {
                        var loginCompletion = new TaskCompletionSource<LoginRadiusResponse> ();
			LoginRadiusHandler handler = new LoginRadiusHandler (loginCompletion, provider);

			SocialLoginViewController svc = new SocialLoginViewController (provider, handler);
                        UINavigationController navVC = new UINavigationController (svc);

                        parent.PresentViewController (navVC, false, null);

                        return loginCompletion.Task;
                }

                public static void Logout ()
                {
                        NSHttpCookieStorage storage = NSHttpCookieStorage.SharedStorage;
                        foreach (NSHttpCookie cookie in storage.Cookies) {
                                storage.DeleteCookie (cookie);
                        }
			LoginRadiusSettings.LoginRadiusAccessToken = "";
			LoginRadiusSettings.LoginRadiusUserProfile = "";
		}
        }
}
