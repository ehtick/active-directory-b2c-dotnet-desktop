﻿using System.Windows;
using Microsoft.Identity.Client;

namespace active_directory_b2c_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly string Tenant = "fabrikamb2c.onmicrosoft.com";
        private static readonly string AzureAdB2CHostname = "login.microsoftonline.com";
        private static readonly string ClientId = "841e1190-d73a-450c-9d68-f5cf16b78e81";
        public static string PolicySignUpSignIn = "b2c_1_susi";
        public static string PolicyEditProfile = "b2c_1_edit_profile";
        public static string PolicyResetPassword = "b2c_1_reset";

        public static string[] ApiScopes = { "https://fabrikamb2c.onmicrosoft.com/helloapi/demo.read" };
        public static string ApiEndpoint = "https://fabrikamb2chello.azurewebsites.net/hello";

        private static string AuthorityBase = $"https://{AzureAdB2CHostname}/tfp/{Tenant}/";
        public static string AuthoritySignInSignUp = $"{AuthorityBase}{PolicySignUpSignIn}";
        public static string AuthorityEditProfile = $"{AuthorityBase}{PolicyEditProfile}";
        public static string AuthorityResetPassword = $"{AuthorityBase}{PolicyResetPassword}";

        public static IPublicClientApplication PublicClientApp { get; private set; }

        static App()
        {
            PublicClientApp = PublicClientApplicationBuilder.Create(ClientId)
                .WithB2CAuthority(AuthoritySignInSignUp)
                .Build();

            TokenCacheHelper.Bind(PublicClientApp.UserTokenCache);
        }
    }
}