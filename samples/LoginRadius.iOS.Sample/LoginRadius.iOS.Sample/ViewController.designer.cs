// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace LoginRadius.iOS.Sample
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton facebookLogin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton logout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton twitterLogin { get; set; }


        [Action ("TwitterLogin_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TwitterLogin_TouchUpInside (UIButton sender);


        [Action ("UIButton37_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton37_TouchUpInside (UIButton sender);


        [Action ("UIButton45_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton45_TouchUpInside (UIButton sender);

        [Action ("Logout_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Logout_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (facebookLogin != null) {
                facebookLogin.Dispose ();
                facebookLogin = null;
            }

            if (logout != null) {
                logout.Dispose ();
                logout = null;
            }

            if (twitterLogin != null) {
                twitterLogin.Dispose ();
                twitterLogin = null;
            }
        }
    }
}