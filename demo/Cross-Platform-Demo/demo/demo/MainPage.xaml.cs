using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinSDK.Api.Authentication;

namespace demo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var token = Preferences.Get("token", "");
            if (token != "")
            {
                DisplayAlert("Alert", "Token= "+token, "OK");
            }
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Preferences.Remove("token");
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

       

    }
}
