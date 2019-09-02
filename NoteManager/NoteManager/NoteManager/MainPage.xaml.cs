using NoteManager.Entities;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace NoteManager
{
    public partial class MainPage : ContentPage
	{
        public ObservableCollection<Note> Notes { get; set; }

        public MainPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            var userId = (Guid)Application.Current.Properties["id"];
            var source = await App.Database.GetNotes(userId);
            Notes = new ObservableCollection<Note>(source);
            NotesList.ItemsSource = Notes;
            base.OnAppearing();
        }

        private async void Add_Btn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NotePage());
        }

        private async void MenuItem_Delete(object sender, System.EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            Notes.Remove((Note)menuItem.CommandParameter);
            await App.Database.DeleteItem((Note)menuItem.CommandParameter);
        }

        private async void MenuItemUpdate_Clicked(object sender, System.EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var note = (Note)menuItem.CommandParameter;
            await Navigation.PushAsync(new NotePage(note));
        }

    }
}