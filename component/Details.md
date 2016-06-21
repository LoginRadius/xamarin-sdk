# LoginRadius

LoginRadius is an Identity Management Platform that simplifies user registration while securing data. LoginRadius Platform simplifies and secures your user registration process, increases conversion with Social Login that combines 30 major social platforms, and offers a full solution with Traditional Customer Registration. You can gather a wealth of user profile data from Social Login or Traditional Customer Registration.

LoginRadius centralizes it all in one place, making it easy to manage and access. Easily integrate LoginRadius with all of your third-party applications, like MailChimp, Google Analytics, Livefyre and many more, making it easy to utilize the data you are capturing.

LoginRadius helps businesses boost user engagement on their web/mobile platform, manage online identities, utilize social media for marketing, capture accurate consumer data, and get unique social insight into their customer base.

Please visit [here](http://www.loginradius.com/) for more information.

Please refer to the documentation for step by step implementation details. [Link](http://apidocs.loginradius.com/docs/xamarin-library-v1)

## Supported Features

### Registration Service

Registration service supports traditional registration and login methods.

Supported actions are __login__, __registration__, __forgotpassword__, __social__

Supported languages are __spanish__, __french__, __german__. For customization please contact [LoginRadius Support](http://support.loginradius.com/hc/en-us/requests/new)

```
// Pass a UIViewController/Activity as parent

LoginRadiusResponse res = await LoginRadiusSDK.RegistrationService (action: "login", language: null, parent: this);

```

### Social Login

Social Login with the given provider.

```
// Pass a UIViewController/Activity as parent

LoginRadiusResponse res = await LoginRadiusSDK.SocialLogin (provider: "facebook", parent: this);

```

### Logout
Log out the user.

```
LoginRadiusSDK.Logout();

```

### Access token and User Profile

After successful login or social login lognradius access token and user profile can be accessed by

```
string user_profile = LoginRadiusSettings.LoginRadiusUserProfile;
string accesss_token = LoginRadiusSettings.LoginRadiusAccessToken;

```
Check the demo app for social login and user registration in action by setting your API key and sitename