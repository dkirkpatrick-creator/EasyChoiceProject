// Authors: Christian Cox & Kyle Daniel Kirkpatrick

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using EasyChoice.Models;
using Xamarin.Forms.Xaml;

namespace EasyChoice
{
    /**
     * The ChoicesPage shows a list of Choices that the user has created
     * for the given ElementSet. Additionally, the user can do many things
     * to interact with the given Choices
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoicesPage : ContentPage
    {
        // Default constructor
        public ChoicesPage()
        {
            InitializeComponent();
        }

        /**
         * When the page is initialized, this method is called to load its
         * contents. The bound ElementSet is initialized and then a list of
         * Choices that are associated with said ElementSet is compiled and
         * displayed onto the page.
         */
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // The ElementSet that contains the Choices that we want
            var elementSet = (ElementSet)BindingContext;
            // A list of all of the Choices associated with the bound ElementSet
            var choices = new List<Choice>();

            // Getting every Choice file associated with the bound ElementSet
            var files = Directory.EnumerateFiles(App.FolderPath, $"*.{elementSet.SetName}_choices.txt");

            // Each iteration, we are creating a new instance of Choice and
            // populating it according to its associated file and then finally
            // adding it to the list of Choices
            foreach (var filename in files)
            {
                choices.Add(new Choice
                {
                    Filename = filename,
                    Name = File.ReadAllText(filename)
                });
            }

            // Ordering the list of Choices alphabetically
            listView.ItemsSource = choices
                .OrderBy(d => d.Name)
                .ToList();
        }

        /**
         * This method is called whenever one of the Choices is clicked 
         * upon/selected. It will push a new ChoiceEntryPage onto the
         * Navigation stack with the selected item bound to it.
         */
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

        /**
         * Associated Button's Text: "+"
         * 
         * Purpose: This method is called when the "+" icon in the ToolBar is
         * clicked. It pushes a new ChoiceEntryPage onto the Navigation stack
         * with a new instance of Choice bound to it using the Choice(string)
         * constructor such that the Choice's "ElementSetName" property is set to the
         * name of the bound ElementSet.
         */
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