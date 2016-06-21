using System;
using ObjCRuntime;
using UIKit;
using LoginRadius.SDK;
using Foundation;

namespace LoginRadius.iOS.Sample
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr p) : base (p)
        {
        }
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            facebookLogin.AddTarget (this, new Selector ("LoginWithFacebook"), UIControlEvent.TouchUpInside);
        }

        [Export ("LoginWithFacebook")]
        async void LoginWithFacebookHandler ()
        {
            LoginRadiusResponse res = await LoginRadiusSDK.SocialLogin (provider: "facebook", parent: this);
            Console.WriteLine (res.ToString ());
        }

        async partial void TwitterLogin_TouchUpInside (UIButton sender)
        {
            LoginRadiusResponse res = await LoginRadiusSDK.SocialLogin ("twitter", this);
            Console.WriteLine (res.ToString ());
        }

        async partial void UIButton37_TouchUpInside (UIButton sender)
        {
            LoginRadiusResponse res = await LoginRadiusSDK.RegistrationService ("registration", null, this);
            Console.WriteLine (res.ToString ());
        }

        async partial void UIButton45_TouchUpInside (UIButton sender)
        {
            LoginRadiusResponse res = await LoginRadiusSDK.RegistrationService (action: "login", language: null, parent: this);
            Console.WriteLine (res.ToString ());
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void Logout_TouchUpInside (UIButton sender)
        {
            LoginRadiusSDK.Logout ();
        }
    }
}


