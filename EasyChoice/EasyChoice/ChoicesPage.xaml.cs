using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using EasyChoice.Models;
using Xamarin.Forms.Xaml;


namespace EasyChoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoicesPage : ContentPage
    {
        public ChoicesPage()
        {
            InitializeComponent();
        }

        // TODO
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var elementSet = (ElementSet)BindingContext; // the elementSet that contains the choices that we want
            var choices = new List<Choice>();

            var files = Directory.EnumerateFiles(App.FolderPath, $"*.{elementSet.SetName}_choices.txt");
            foreach (var filename in files)
            {
                choices.Add(new Choice
                {
                    Filename = filename,
                    Name = File.ReadAllText(filename)
                });
            }

            // could modify these so that they are ordered by date
            listView.ItemsSource = choices
                .OrderBy(d => d.Name)
                .ToList();
        }

        // TODO: implement
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ChoiceEntryPage
                {
                    BindingContext = e.SelectedItem as Choice
                });
            }
        }

        // TODO
        async void OnAddChoiceButtonClicked(object sender, EventArgs e)
        {
            var elementSet = (ElementSet)BindingContext;
            await Navigation.PushAsync(new ChoiceEntryPage
            {
                BindingContext = new Choice(elementSet.SetName)
            });
        }
    }
}