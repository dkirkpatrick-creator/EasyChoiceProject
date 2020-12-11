// Authors: Christian Cox & Kyle Daniel Kirkpatrick

using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EasyChoice.Models;

namespace EasyChoice
{
    // The ChoiceEntryPage is a page where the user can input and edit a custom Choice.
    // Additionally, the user can delete a Choice through this page.
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoiceEntryPage : ContentPage
    {
        // Default constructor
        public ChoiceEntryPage()
        {
            InitializeComponent();
        }

        /**
         * Associated Button's Text: "Save"
         * 
         * Purpose: When the user clicks on this button, the Choice's name that
         * they have entered will be saved/updated to a file. If the user did not
         * input any text, then the application will display an Alert, tellinng them
         * that they have input an "Invalid Entry", and the null or empty Choice
         * will not be saved.
         */
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
                choice.Filename = filename;
                File.WriteAllText(filename, choice.Name);
            }
            else
            {
                // Update
                File.WriteAllText(choice.Filename, choice.Name);
            }

            // Checking to make sure that the file was actually added
            Debug.Debug.Assert(File.Exists(choice.Filename));

            await Navigation.PopAsync();
        }

        /**
         * Associated Button's Text: "Delete"
         * 
         * Purpose: When the user clicks on this button, the Choice's file is
         * deleted (based off of the "Filename" property of Choice).
         */
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var choice = (Choice)BindingContext;

            if (File.Exists(choice.Filename))
            {
                File.Delete(choice.Filename);
            }

            // Checking to make sure that the file was actually deleted by seeing
            // if the file doesn't exist
            Debug.Debug.Assert(!File.Exists(choice.Filename));

            await Navigation.PopAsync();
        }
    }
}