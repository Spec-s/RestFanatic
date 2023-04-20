using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Microsoft.Maui.Controls;
using Renci.SshNet;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace FoodFanatics.ViewModels;

public partial class registrationpageviewmodel : BaseViewModels
{
    //private string email;
    //private string password;
    //private string confirmpassword;

    //public string webapikey = "aizasycxg5cyjg0kdqsswxqqqrod8qpaj7k4zlg";

    //public event PropertyChangedEventHandler propertychanged;

    //private INavigationPageController _navigation;

    //public Command registeruser { get; }

    //public string Email
    //{
    //    get => email;
    //    set
    //    {
    //        email = value;
    //        raisepropertychanged("email");
    //    }
    //}

    //public string Password
    //{
    //    get => password; set
    //    {
    //        password = value;
    //        raisepropertychanged("password");
    //    }
    //}



    //private void raisepropertychanged(string v)
    //{
    //    propertychanged?.Invoke(this, new PropertyChangedEventArgs(v));
    //}

    //public registrationpageviewmodel(INavigationPageController navigation)
    //{
    //    this._navigation = navigation;

    //    registeruser = new RelayCommand(registerusertappedasync);
    //}

    //[RelayCommand]
    //private async void registerusertappedasync(object obj)
    //{
    //    try
    //    {
    //        var authprovider = new FirebaseAuthProvider(new FirebaseConfig(webapikey));
    //        var auth = await authprovider.CreateUserWithEmailAndPasswordAsync(email, password);
    //        string token = auth.FirebaseToken;
    //        if (token != null)
    //            await App.Current.MainPage.DisplayAlert("alert", "user registered successfully", "ok");
    //        await this._navigation.PopAsyncInner();
    //    }
    //    catch (Exception)
    //    {
    //        await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("error", "unable to register user", "ok");
    //        throw;
    //    }
    //}

}