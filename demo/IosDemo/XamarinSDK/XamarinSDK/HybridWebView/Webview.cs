using Xamarin.Forms;

namespace XamarinSDK.HybridWebView
{
    public class Webview : ContentPage
    {
        public Webview(string uri)
        {

            WebView webview = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = uri,


                },
                VerticalOptions = LayoutOptions.FillAndExpand

            };
            this.Content = new StackLayout
            {
                Children = {
                     webview
                }
            };

         
        }


       
    }
}