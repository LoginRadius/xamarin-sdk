using System;
using System.Web;
using UIKit;
using ObjCRuntime;
using Foundation;
using CoreGraphics;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace LoginRadius.iOS
{
        public partial class SocialLoginViewController : UIViewController
        {

                UIWebView WebView;
                string Provider;
                TaskCompletionSource<string> completion;

                public SocialLoginViewController () : base ("SocialLoginViewController", null)
                {
                }

                public SocialLoginViewController (string socialProvider, TaskCompletionSource<string> comp)
                {
                        Provider = socialProvider;
                        completion = comp;
                }

                public override void ViewDidLoad ()
                {
                        base.ViewDidLoad ();

                        WebView = new UIWebView (View.Bounds);
                        WebView.ScalesPageToFit = true;
                        WebView.ShouldStartLoad = ShouldStartLoadWithRequest;
                        View.AddSubview (WebView);
                }

                public override void ViewWillAppear (bool animated)
                {
                        base.ViewWillAppear (animated);
			
                        UIBarButtonItem cancelItem = new UIBarButtonItem (UIBarButtonSystemItem.Cancel, this, new Selector ("CancelPressed"));
                        this.NavigationItem.SetLeftBarButtonItem (cancelItem, false);

                        string url = "https://" + LoginRadiusSDK.SiteName + ".hub.loginradius.com/RequestHandlor.aspx?apikey=" + LoginRadiusSDK.ApiKey + "&provider=" + Provider + "&ismobile=1";
                        WebView.LoadRequest (new NSUrlRequest (new NSUrl (url)));
                }

                public override void ViewWillDisappear (bool animated)
                {
                        base.ViewWillDisappear (animated);
                        WebView.StopLoading ();
                }

                public override void ViewDidLayoutSubviews ()
                {
                        WebView.Frame = new CGRect (0, 0, View.Frame.Size.Width, View.Frame.Size.Height);
                }

                private bool ShouldStartLoadWithRequest (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
                {
                        if (request.Url.AbsoluteString.IndexOf ("token") != -1 && request.Url.Path.Equals ("/mobile.aspx")) {
                                NameValueCollection parameters = HttpUtility.ParseQueryString (request.Url.Query);
                                string token = parameters ["token"];

                                if (!String.IsNullOrEmpty (token)) {
                                        string userProfile = RestClient.Request (string.Format ("https://api.loginradius.com/api/v2/userprofile?access_token={0}", token), null, HttpMethod.GET);
                                        this.DismissViewController (true, null);
                                        completion.SetResult (userProfile);
                                } else {
                                        // Finish Login with error
                                        this.DismissViewController (true, null);
                                        completion.SetException (new Exception ("Token null or empty"));
                                }

                                return true;
                        }

                        return true;
                }


                [Export ("CancelPressed")]
                public void CancelPressed ()
                {
                        this.DismissViewController (true, null);
                        completion.SetCanceled ();
                }

                public void finishLogin (bool success, NSError error)
                {
                        if (success) {
                                this.DismissViewController (true, null);
                        }
                }
        }
}
