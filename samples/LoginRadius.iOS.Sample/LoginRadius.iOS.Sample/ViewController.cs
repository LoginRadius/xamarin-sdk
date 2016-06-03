using System;
using ObjCRuntime;
using UIKit;
using LoginRadius.SDK;
using Foundation;

namespace LoginRadius.iOS.Sample
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr p) : base(p)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            facebookLogin.AddTarget (this, new Selector ("LoginWithFacebook"), UIControlEvent.TouchUpInside);
        }

        [Export ("LoginWithFacebook")]
        async void LoginWithFacebookHandler ()
        {
            try {
                string user = await LoginRadiusSDK.SocialLogin(provider:"facebook", parent:this);
                Console.WriteLine(user);
            } catch {
                
            }
        }

        async partial void TwitterLogin_TouchUpInside(UIButton sender)
        {
            try {
                string user = await LoginRadiusSDK.SocialLogin("twitter", this);
                Console.WriteLine(user);    
            } catch {
                
            }
        }

        async partial void UIButton37_TouchUpInside(UIButton sender)
        {
            try {
                string user = await LoginRadiusSDK.RegistrationService("registration", null, this);
                Console.WriteLine(user);
            } catch {
                
            }
        }

        async partial void UIButton45_TouchUpInside(UIButton sender)
        {
            try {
                string user = await LoginRadiusSDK.RegistrationService(action:"login", language:null, parent:this);
                Console.WriteLine(user);
            } catch {
                
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


