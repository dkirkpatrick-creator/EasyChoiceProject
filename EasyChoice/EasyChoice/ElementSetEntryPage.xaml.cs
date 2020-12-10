using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EasyChoice.Models;
using System.Collections.Generic;

namespace EasyChoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElementSetEntryPage : ContentPage
    {
        public ElementSetEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var elementSet = (ElementSet)BindingContext;

            // Checking to make sure that the user entered something in the "SetName" field before moving on
            if (string.IsNullOrWhiteSpace(elementSet.SetName))
            {
                await DisplayAlert("Invalid Entry", "Please enter a name for the given ElementSet", "OK");
                return; // stops the user from continuing if they didn't enter anything
            }

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

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            // Deleting the ElementSet's file
            var elementSet = (ElementSet)BindingContext;

            if (File.Exists(elementSet.Filename))
            {
                File.Delete(elementSet.Filename);
            }

            // Deleting the Choice files linked to the ElementSet we want to delete

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

        async void OnEditChoicesButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            ElementSet elementSet = button.CommandParameter as ElementSet;

            // Checking to make sure that the user entered something in the "SetName" field before moving on
            if (string.IsNullOrWhiteSpace(elementSet.SetName))
            {
                await DisplayAlert("Invalid Entry", "Please enter a name for the given ElementSet", "OK");
                return; // stops the user from continuing if they didn't enter anything
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