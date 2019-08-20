using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace demo
{
    public partial class LRWebview : ContentPage
    {
        public LRWebview(string url)
        {
            InitializeComponent();
            var browser = new WebView();
            browser.Source = url;
            Content = browser;
            browser.Navigated += (sender, e) => {

                var changedUrl = ((WebView)sender).Source;
                var finalUrl = changedUrl.GetType().GetProperty("Url").GetValue(changedUrl, null);
                if (finalUrl.ToString().Contains("?token"))
                {
                    string dict =  GetParams(finalUrl.ToString());
                    Preferences.Set("token", dict);
                    Navigation.InsertPageBefore(new MainPage(), this);
                    Navigation.PopAsync();
                }
                
                //hello
            };


        }

        private static string GetParams(string uri)
        {
            var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
            string value ="";
            foreach (Match m in matches)
                if (Uri.UnescapeDataString(m.Groups[2].Value) == "token")
                {
                    value =  Uri.UnescapeDataString(m.Groups[3].Value).ToString();
                }

            return value;
        }

    }
}
