using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EasyChoice.Models;

namespace EasyChoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoiceEntryPage : ContentPage
    {
        public ChoiceEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var choice = (Choice)BindingContext;

            // Checking to make sure that the user entered something in the "Name" field before moving on
            if (string.IsNullOrWhiteSpace(choice.Name))
            {
                await DisplayAlert("Invalid Entry", "Please enter a name for the given Choice before saving.", "OK");
                return; // stops the user from continuing if they didn't enter anything
            }

            if (string.IsNullOrWhiteSpace(choice.Filename))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.{choice.ElementSetName}_choices.txt");
                File.WriteAllText(filename, choice.Name);
            }
            else
            {
                // Update
                File.WriteAllText(choice.Filename, choice.Name);
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var choice = (Choice)BindingContext;

            if (File.Exists(choice.Filename))
            {
                File.Delete(choice.Filename);
            }

            await Navigation.PopAsync();
        }
    }
}