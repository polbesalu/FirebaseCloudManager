using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth.UI;
using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FirebaseCloudManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Force override culture & language
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("cs");
            //CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("cs");

            // Firebase UI initialization
            FirebaseUI.Initialize(new FirebaseUIConfig
            {
                //Cambiar ApiKey
                ApiKey = "AIzaSyDjDnzwMC8G-UZPjQgANh7v0t5tuEcKlbY",
                AuthDomain = "provafirebase-e63fd.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new GoogleProvider(),
                    new EmailProvider()
                },
                PrivacyPolicyUrl = "https://github.com/step-up-labs/firebase-authentication-dotnet",
                TermsOfServiceUrl = "https://github.com/step-up-labs/firebase-database-dotnet",
                IsAnonymousAllowed = true,
                AutoUpgradeAnonymousUsers = true,
                UserRepository = new FileUserRepository("FirebaseSample"),
                // Func called when upgrade of anonymous user fails because the user already exists
                // You should grab any data created under your anonymous user, sign in with the pending credential
                // and copy the existing data to the new user
                // see details here: https://github.com/firebase/firebaseui-web#upgrading-anonymous-users
                AnonymousUpgradeConflict = conflict => conflict.SignInWithPendingCredentialAsync(true)
            });
        }
    }
}
