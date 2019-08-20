using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinSDK.Api.Authentication;
using XamarinSDK.Models.UserProfile;

namespace demo
{
    public partial class SignUpPage : ContentPage
    {

        string apiKey = "";
        string sott = "";
        public SignUpPage()
        {
            InitializeComponent();
        }
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
        
            UserIdentityCreateModel user = new UserIdentityCreateModel();
            user.FirstName = firstnameEntry.Text;
            
            user.Password = passwordEntry.Text;

            Email email1 = new Email();
            email1.Type = "Primary";
            email1.Value = emailEntry.Text;
            user.Email = new List<Email>();
            user.Email.Add(email1);
            // Sign up logic goes here

            await UserRegistrationbyEmailAPI.GetUserRegistrationbyEmail(apiKey, sott, "", "", user, response => {
                
                DisplayAlert("Alert", "hello Registration is Sucessfull", "OK");
                Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                Navigation.PopToRootAsync();  // Success event
            }, (error) => {
                messageLabel.Text = error.description;             // Failure event
            });
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }
    }
}
