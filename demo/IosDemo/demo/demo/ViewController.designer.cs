// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace demo
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton facebook { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton google { get; set; }

        [Action ("Facebook_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Facebook_TouchUpInside (UIKit.UIButton sender);

        [Action ("Google_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Google_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (facebook != null) {
                facebook.Dispose ();
                facebook = null;
            }

            if (google != null) {
                google.Dispose ();
                google = null;
            }
        }
    }
}