// Authors: Christian Cox & Kyle Daniel Kirkpatrick

using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EasyChoice.Models;
using System.Collections.Generic;

namespace EasyChoice
{

    /**
     * The ElementSetEntryPage is a page where the user can input and edit a
     * custom ElementSet. Additionally, the user can delete an ElementSet through
     * this page and edit all of the Choices linked to it.
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElementSetEntryPage : ContentPage
    {
        // Default constructor
        public ElementSetEntryPage()
        {
            InitializeComponent();
        }

        /**
         * Associated Button's Text: "Save"
         * 
         * Purpose: When the user clicks on this button, the ElementSet's SetName
         * that they have entered will be saved/updated to a file. If the user
         * did not input any text, then the application will display an Alert, tellinng them
         * that they have input an "Invalid Entry", and the null or empty ElementSet
         * will not be saved.
         * 
         * NOTE: Because of the nature of how ElementSets and their choices are linked
         * (by their Filenames), we must update the Choices' files in addition to
         * the ElementSet's whenever we change the ElementSet's SetName.
         */
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var elementSet = (ElementSet)BindingContext;

            // Checking to make sure that the user entered something in the "SetName" field before moving on
            if (string.IsNullOrWhiteSpace(elementSet.SetName))
            {
                await DisplayAlert("Invalid Entry", "Please enter a name for the given ElementSet.", "OK");
                return; // This stops the user from continuing if they didn't enter anything
            }

            if (string.IsNullOrWhiteSpace(elementSet.Filename))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.elementSets.txt");
                File.WriteAllText(filename, elementSet.SetName);
            }
            else
            {
                var oldSetName = File.ReadAllText(elementSet.Filename);
                // -=Updating each Choice file connected to the ElementSet=-

                // Getting every Choice file associated with the bound ElementSet
                var files = Directory.EnumerateFiles(App.FolderPath, $"*.{oldSetName}_choices.txt");

                // Each iteration, we are creating a new instance of Choice and
                // populating it according to its associated file
                foreach (var filename in files)
                {
                    Choice choice = new Choice
                    {
                        Filename = filename,
                        Name = File.ReadAllText(filename),
                        ElementSetName = elementSet.SetName
                    };

                    // Deleting the Choice's old file
                    if (File.Exists(choice.Filename))
                    {
                        File.Delete(choice.Filename);
                    }

                    // Creating a new file for this Choice
                    var newFilename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.{choice.ElementSetName}_choices.txt");
                    choice.Filename = newFilename;
                    File.WriteAllText(newFilename, choice.Name);
                }

                // Update
                File.WriteAllText(elementSet.Filename, elementSet.SetName);
            }

            await Navigation.PopAsync();
        }

        /**
         * Associated Button's Text: "Delete"
         * 
         * Purpose: When the user clicks on this button, the ElementSet's file
         * is deleted (based off of the "Filename" property of ElementSet).
         * Additionally, every file of every Choice that is associated with this
         * ElementSet is deleted.
         */
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            // Deleting the ElementSet's file
            var elementSet = (ElementSet)BindingContext;

            if (File.Exists(elementSet.Filename))
            {
                File.Delete(elementSet.Filename);
            }

            // -=Deleting the Choice files linked to the ElementSet we want to delete=- //

            // Every Choice file that is linked to the current ElementSet we are deleting
            var files = Directory.EnumerateFiles(App.FolderPath, $"*.{elementSet.SetName}_choices.txt");
            foreach (var filename in files)
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }

            await Navigation.PopAsync();
        }

        /**
         * Associated Button's Text: "Edit Choices"
         * 
         * Purpose: When the user clicks on this button, a new ChoicesPage
         * (a page that displays all of the Choices linked to bound ElementSet)
         * is pushed onto the Navigation stack, with the ElementSet whose Choices
         * we want to edit bound to it.
         * 
         * However, before this is done, the method makes sure that the ElementSet's
         * "SetName" property is not empty or null. If it is, an Alert is displayed,
         * saying that the user has entered an "Invalid Entry" and that they must
         * try again, ending the method call.
         * 
         * Additionally, the method saves the current ElementSet's file before moving
         * on, just in case the user has forgotten to do so.
         */
        async void OnEditChoicesButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            ElementSet elementSet = button.CommandParameter as ElementSet;

            // Checking to make sure that the user entered something in the "SetName" field before moving on
            if (string.IsNullOrWhiteSpace(elementSet.SetName))
            {
                await DisplayAlert("Invalid Entry", "Please enter a name for the given ElementSet.", "OK");
                return; // This stops the user from continuing if they didn't enter anything
            }

            // Saving the ElementSet before moving on to the "ChoicesPage", just in case
            if (string.IsNullOrWhiteSpace(elementSet.Filename))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.elementSets.txt");
                File.WriteAllText(filename, elementSet.SetName);
            }
            else
            {
                // Update
                File.WriteAllText(elementSet.Filename, elementSet.SetName);
            }

            if (elementSet != null)
            {
                await Navigation.PushAsync(new ChoicesPage
                {
                    BindingContext = elementSet
                });
            }
        }
    }
}