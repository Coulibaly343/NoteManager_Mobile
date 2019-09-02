using NoteManager.Entities;
using Plugin.Connectivity;
using System;
using Xamarin.Forms;

namespace NoteManager
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            if (CrossConnectivity.Current.IsConnected)
                connectionCheck.Text = "Connection: OK";
            else
                connectionCheck.Text = "Connection: NO";
        }

        async void Register_Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        async void Submit_Btn_Clicked(object sender, EventArgs e)
        {
            var login = loginEntry?.Text;
            var password = passwordEntry?.Text;
            var user = await App.Database.GetByLogin(login);

            if (user.Equals(null))
            {
                await DisplayAlert("Error", "Wrong username or password", "Ok");
            }

            Application.Current.Properties["id"] = user.Id;

            var (ifEmpty, ifCredentialsCorrect) = Validation(login, password, user);

            if (!ifEmpty && ifCredentialsCorrect)
                await Navigation.PushAsync(new MainPage());
            else
                await DisplayAlert("Error", "Wrong username or password", "Back");
        }

        public static (bool, bool) Validation(string login, string password, User user)
        {
            var checkIfEmpty = string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password);
            var checkLogin = (login == user.Login) && (password == user.Password);
            return (checkIfEmpty, checkLogin);
        }

    }
}