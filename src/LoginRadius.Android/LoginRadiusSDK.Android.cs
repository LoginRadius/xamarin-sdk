using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Webkit;

namespace LoginRadius.SDK
{
	public partial class LoginRadiusSDK
	{
		public static Task<LoginRadiusResponse> RegistrationService (string action, string language, Activity parent)
		{
			var taskCompletionSource = new TaskCompletionSource<LoginRadiusResponse> ();
			LoginRadiusHandler handler = new LoginRadiusHandler (taskCompletionSource, action);

			RegistrationServiceActivity.handler = handler;
			Intent intent = new Intent (parent, typeof (RegistrationServiceActivity));
			intent.PutExtra ("action", action);
			intent.PutExtra ("language", language);
			parent.StartActivity (intent);

			return taskCompletionSource.Task;
		}

		public static Task<LoginRadiusResponse> SocialLogin (string provider, Activity parent)
		{
			var taskCompletionSource = new TaskCompletionSource<LoginRadiusResponse> ();
			LoginRadiusHandler handler = new LoginRadiusHandler (taskCompletionSource, provider);

			SocialLoginActivity.handler = handler;
			Intent intent = new Intent (parent, typeof (SocialLoginActivity));
			intent.PutExtra ("provider", provider);
			parent.StartActivity (intent);

			return taskCompletionSource.Task;
		}

		public static void Logout ()
		{
			CookieManager cm = CookieManager.Instance;
			cm.RemoveAllCookie ();
			LoginRadiusSettings.LoginRadiusAccessToken = "";
			LoginRadiusSettings.LoginRadiusUserProfile = "";
		}
	}
}
