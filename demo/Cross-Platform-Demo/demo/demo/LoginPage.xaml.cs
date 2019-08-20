using System;
using System.Collections.Generic;
using XamarinSDK.HybridWebView;
using Xamarin.Forms;
using Xamarin.Essentials;
using XamarinSDK.Api.Authentication;

namespace demo
{

    
    public partial class LoginPage : ContentPage
    {

        string apikey = "";
        string siteName = "";
        public LoginPage()
        {
            InitializeComponent();
            
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnFacebookButtonClicked(object sender, EventArgs e) {

            WebViewUrl web = new WebViewUrl();
            Dictionary<string, string> webview = new Dictionary<string, string>();
            webview.Add("appname", siteName);
            webview.Add("apikey", apikey);
            webview.Add("provider", "facebook");
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new LRWebview(web.getWebUrl(webview)));

        }


        async void OnGoogleButtonClicked(object sender, EventArgs e)
        {

            WebViewUrl web = new WebViewUrl();
            Dictionary<string, string> webview = new Dictionary<string, string>();
            webview.Add("appname", siteName);
            webview.Add("apikey", apikey);
            webview.Add("provider", "google");
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new LRWebview(web.getWebUrl(webview)));

        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
           
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("apikey", apikey);
            data.Add("email", emailEntry.Text);
            data.Add("password", passwordEntry.Text);

            await LoginbyEmailAPI.GetLoginbyEmail(data, response => {
                // Success event
                Preferences.Set("token", response.access_token);
                DisplayAlert("Alert", "hello" + response.Profile.FirstName, "OK");
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                Navigation.PopAsync();
            }, (error) => {
                messageLabel.Text = error.description;
                passwordEntry.Text = string.Empty;               // Failure event   
            });
        }


    }

}
