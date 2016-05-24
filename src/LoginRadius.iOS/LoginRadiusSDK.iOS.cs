using System;
using UIKit;

namespace LoginRadius.iOS
{
	public partial class LoginRadiusSDK
	{
		public void RegistrationService (string action, UIViewController parent) 
		{

		}

		public void SocialLogin (string provider, UIViewController parent) 
		{
			SocialLoginViewController svc = new SocialLoginViewController (provider);
			parent.PresentViewController (svc, false, null);
		
		}

		public void Logout ()
		{
			
		}
	}
}

