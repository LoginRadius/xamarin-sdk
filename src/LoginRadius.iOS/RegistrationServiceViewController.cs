using System;
using System.Web;
using System.Collections.Specialized;
using System.Threading.Tasks;
using UIKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

namespace LoginRadius.iOS
{
    public partial class RegistrationServiceViewController : UIViewController
    {

        UIWebView WebView;
        string Action;
        string Language;

        TaskCompletionSource<string> completion;


        public RegistrationServiceViewController()
            : base("RegistrationServiceViewController", null)
        {
        }
           
        public RegistrationServiceViewController (string registrationAction, TaskCompletionSource<string> comp) {
            Action = registrationAction;
            completion = comp;
            Language = "";
        }

        public RegistrationServiceViewController (string registrationAction, string language ,TaskCompletionSource<string> comp) {
            Action = registrationAction;
            completion = comp;
            Language = language;
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            WebView = new UIWebView(View.Bounds);
            WebView.ScalesPageToFit = true;
            WebView.ShouldStartLoad = ShouldStartLoadWithRequest;
            View.AddSubview(WebView);
        }

        public override void ViewWillAppear (bool animated)
        {
            base.ViewWillAppear(animated);

            UIBarButtonItem cancelItem = new UIBarButtonItem (UIBarButtonSystemItem.Cancel, this, new Selector ("CancelPressed"));
            this.NavigationItem.SetLeftBarButtonItem(cancelItem, false);

            string language = "";

            if (!String.IsNullOrEmpty(Language))
            {
                language = "-" + Language;
            }
                
            string url = "https://cdn.loginradius.com/hub/prod/Theme/mobile"+ language + "/index.html?apikey=" + LoginRadiusSDK.ApiKey+ "&sitename=" + LoginRadiusSDK.SiteName + "&action=" + Action;
            WebView.LoadRequest (new NSUrlRequest (new NSUrl (url)));
        }

        public override void ViewDidLayoutSubviews ()
        {
            WebView.Frame = new CGRect(0, 0, View.Frame.Size.Width, View.Frame.Size.Height);
        }

        private bool ShouldStartLoadWithRequest(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
        {
            Console.Write (request.Url.ToString ());

            NameValueCollection parameters = HttpUtility.ParseQueryString (request.Url.Query);
            string returnAction = parameters["action"];
            string absString = request.Url.AbsoluteString;

            if(returnAction.Equals("registration")) {

                if (absString.IndexOf("status")!= -1) {
                    this.finishRaaSAction(true, null);
                }
            
            } else if(returnAction.Equals("login")) {
                if (absString.IndexOf("lrtoken")!= -1) {
                    string token = parameters["lrtoken"];

                    string userProfile = RestClient.Request(string.Format("https://api.loginradius.com/api/v2/userprofile?access_token={0}", token), null, HttpMethod.GET);
                    completion.SetResult(userProfile);
                    this.finishRaaSAction(true, null);
                }

            } else if (returnAction.Equals("forgotpassword")) {

                if (absString.IndexOf("status")!= -1) {
                    this.finishRaaSAction(true, null);
                }

            } else if (returnAction.Equals("sociallogin")) {

                if (absString.IndexOf("lrtoken") != -1)
                {
                    string token = parameters["lrtoken"];
                    string userProfile = RestClient.Request(string.Format("https://api.loginradius.com/api/v2/userprofile?access_token={0}", token), null, HttpMethod.GET);
                    completion.SetResult(userProfile);
                    this.finishRaaSAction(true, null);
                }
            }
            return true;
        }


        [Export ("CancelPressed")]
        public void CancelPressed ()
        {
            this.DismissViewController (true, null);
            // this will crash the app with exception
            completion.SetCanceled();
        }

        public void finishRaaSAction (bool success, NSError error) {
            if (success)
            {
                this.DismissViewController (true, null);
            }
        }
    }
}


