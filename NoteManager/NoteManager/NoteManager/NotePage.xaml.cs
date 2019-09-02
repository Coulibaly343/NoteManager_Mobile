
using NoteManager.Entities;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {
        private Note _note { get; set; }

        public NotePage()
        {
            InitializeComponent();
            updateBtn.IsVisible = false;
            saveBtn.IsVisible = true;
        }

        public NotePage(Note note)
        {
            InitializeComponent();
            updateBtn.IsVisible = true;
            saveBtn.IsVisible = false;
            _note = note;
            Title.Text = _note.Title;
            Description.Text = _note.Content;
        }

        private async void Add_Btn_Clicked(object sender, System.EventArgs e)
        {
            var userId = (Guid) Application.Current.Properties["id"];
            var note = new Note(Title.Text, Description.Text, userId);
            await DisplayAlert("Saved", "Note has been saved succesfuly!", "Ok");
            await App.Database.SaveItem(note);
            await Navigation.PopAsync();
        }

        private async void Update_Btn_Clicked(object sender, System.EventArgs e)
        {
            _note.Title = Title.Text;
            _note.Content = Description.Text;
            await DisplayAlert("Updated", "Note has been updated succesfuly!", "Ok");
            await App.Database.SaveItem(_note);
            await Navigation.PopAsync();
        }
    }
}