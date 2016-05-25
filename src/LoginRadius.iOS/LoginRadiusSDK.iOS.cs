using System;
using UIKit;

namespace LoginRadius.iOS
{
	public partial class LoginRadiusSDK
	{
		public void RegistrationService (string action, UIViewController parent) 
		{

		}

        public Task<string> SocialLogin (string provider, UIViewController parent) 
		{
            var loginCompletion = new TaskCompletionSource<string> ();

            SocialLoginViewController svc = new SocialLoginViewController (provider, loginCompletion);
            UINavigationController navVC = new UINavigationController(svc);

            parent.PresentViewController (navVC, false, null);

            return loginCompletion.Task;
		}

		public void Logout ()
		{
			
		}
	}
}
