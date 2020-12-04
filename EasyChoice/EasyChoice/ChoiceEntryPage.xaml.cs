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

        // TODO: working on this one
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var choice = (Choice)BindingContext;

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