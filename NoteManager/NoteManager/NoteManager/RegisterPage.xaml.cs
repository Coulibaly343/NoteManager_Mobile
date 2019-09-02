using NoteManager.Entities;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        async void Btn_Clicked(object sender, EventArgs e)
        {
            var login = loginEntry?.Text;
            var name = nameEntry?.Text;
            var surname = surnameEntry?.Text;
            var password = passwordEntry?.Text;
            var reenteredPass = reEnterPassword?.Text;

            if (await Validate(login, password, reenteredPass))
            {
                var user = new User(name, surname, login, password);
                await App.Database.SaveItem(user);
                await DisplayAlert("Register successfuly!", "You are signed up!", "Ok");
                await Navigation.PopAsync();
            }
        }

        private async Task<bool> Validate(string login, string password,
            string reenteredPass)
        {
            var user = await App.Database.GetByLogin(login);

            if (user != null)
            {
                await DisplayAlert("Error", "User already exist", "Back");
                return false;
            }
            if (string.IsNullOrEmpty(login) || login.Length < 2)
            {
                await DisplayAlert("Error", "Login it is empty or too short!", "Back");
                return false;
            }
            if (password.Length < 5)
            {
                await DisplayAlert("Error", "Password has to be: min 5 letters", "Ok");
                return false;
            }
            if (!reenteredPass.Equals(password))
            {
                await DisplayAlert("Error", "Passwords are not equal!", "Back");
                return false;
            }
            return true;
        }

    }
}