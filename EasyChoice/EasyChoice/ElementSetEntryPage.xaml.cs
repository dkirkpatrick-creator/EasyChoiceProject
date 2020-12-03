using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EasyChoice.Models;

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
            var elementSet = (ElementSet)BindingContext;

            if (File.Exists(elementSet.Filename))
            {
                File.Delete(elementSet.Filename);
            }

            await Navigation.PopAsync();
        }
    }
}