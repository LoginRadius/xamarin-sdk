using System;
using System.Web;
using UIKit;
using ObjCRuntime;
using Foundation;
using CoreGraphics;
using System.Collections.Specialized;

namespace LoginRadius.iOS
{
	public partial class SocialLoginViewController : UIViewController
	{

		UIWebView WebView;
		string Provider;

		public SocialLoginViewController () : base ("SocialLoginViewController", null)
		{
		}

		public SocialLoginViewController (string socialProvider) {
			Provider = socialProvider;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear(animated);
			UIBarButtonItem cancelItem = new UIBarButtonItem (UIBarButtonSystemItem.Cancel, this, new Selector ("CancelPressed"));
			this.NavigationItem.LeftBarButtonItem = cancelItem;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			WebView = new UIWebView(View.Bounds);
			WebView.ScalesPageToFit = true;
			WebView.ShouldStartLoad = ShouldStartLoadWithRequest;

			View.AddSubview(WebView);

			string url = "https://" + LoginRadiusSDK.SiteName + ".hub.loginradius.com/RequestHandlor.aspx?apikey=" + LoginRadiusSDK.ApiKey + "&provider=" + Provider + "&ismobile=1";

			WebView.LoadRequest (new NSUrlRequest (new NSUrl (url)));
		}

		public override void ViewDidLayoutSubviews ()
		{
			WebView.Frame = new CGRect(0, 0, View.Frame.Size.Width, View.Frame.Size.Height);
		}

		private bool ShouldStartLoadWithRequest(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			Console.Write (request.Url.ToString ());

			if (request.Url.AbsoluteString.IndexOf ("token") != -1 && request.Url.Path.Equals ("/mobile.aspx"))
			{
				this.DismissViewController (true, null);


				NameValueCollection parameters = HttpUtility.ParseQueryString (request.Url.Query);

				string token = parameters ["token"];

				if (!String.IsNullOrEmpty(token))
				{
					// TODO: Fetch user data
					this.finishLogin(true, null);

				} else {
					// Finish Login with error

				}

				return true;
			}

			return true;
		}


		[Export ("CancelPressed")]
		public void CancelPressed ()
		{
			this.DismissViewController (true, null);
		}

		public void finishLogin (bool success, NSError error) {
			if (success)
			{
				this.DismissViewController (true, null);
			}
		}
	}
}
