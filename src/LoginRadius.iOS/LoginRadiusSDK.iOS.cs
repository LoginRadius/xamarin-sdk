using System;
using System.Threading.Tasks;
using UIKit;

namespace LoginRadius.iOS
{
        public partial class LoginRadiusSDK
        {
                public Task<string> RegistrationService (string action, string language, UIViewController parent)
                {
                        var rsCompletion = new TaskCompletionSource<string> ();

                        RegistrationServiceViewController rvc = new RegistrationServiceViewController (action, language, rsCompletion);
                        UINavigationController navVC = new UINavigationController (rvc);

                        parent.PresentViewController (navVC, false, null);

                        return rsCompletion.Task;
                }

                public Task<string> SocialLogin (string provider, UIViewController parent)
                {
                        var loginCompletion = new TaskCompletionSource<string> ();

                        SocialLoginViewController svc = new SocialLoginViewController (provider, loginCompletion);
                        UINavigationController navVC = new UINavigationController (svc);

                        parent.PresentViewController (navVC, false, null);

                        return loginCompletion.Task;
                }

                public void Logout ()
                {
			
                }
        }
}
