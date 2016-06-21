using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LoginRadius.SDK
{
        public static class LoginRadiusSettings
        {
                private static ISettings AppSettings {
                        get {
                                return CrossSettings.Current;
                        }
                }

                private const string lrAccessToken = "lr-accesstoken";
                private static readonly string AccessTokenDefault = string.Empty;

                private const string lrUserProfile = "lr-userprofile";
                private static readonly string UserProfileDefault = string.Empty;

                public static string LoginRadiusAccessToken {
                        get { return AppSettings.GetValueOrDefault<string> (lrAccessToken, AccessTokenDefault); }
                        set { AppSettings.AddOrUpdateValue<string> (lrAccessToken, value); }
                }

                public static string LoginRadiusUserProfile {
                        get { return AppSettings.GetValueOrDefault<string> (lrUserProfile, UserProfileDefault); }
                        set { AppSettings.AddOrUpdateValue<string> (lrUserProfile, value); }
                }
        }
}
