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
     * The ElementSetPage shows a list of ElementSets that the user has created.
     * Additionally, the user can do many to interact with the given ElementSets.
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElementSetPage : ContentPage
    {
        // Default constructor
        public ElementSetPage()
        {
            InitializeComponent();
        }

        /**
         * When the page is initialized, this method is called to load its
         * contents. A list of ElementSets is then compiled and displayed onto
         * the page.
         */
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // A list of all of the ElementSets that the user has created
            var elementSets = new List<ElementSet>();

            // Getting every ElementSet file
            var files = Directory.EnumerateFiles(App.FolderPath, "*.elementSets.txt");

            // Each iteration, we are creating a new instance of ElementSet and
            // populating it according to its associated file and then finally
            // adding it to the list of ElementSets
            foreach (var filename in files)
            {
                elementSets.Add(new ElementSet
                {
                    Filename = filename,
                    SetName = File.ReadAllText(filename)
                });
            }

            // Ordering the list of ElementSets alphabetically
            listView.ItemsSource = elementSets
                .OrderBy(d => d.SetName)
                .ToList();
        }

        /**
         * This method is called whenever one of the ElementSets is clicked
         * upon/selected. It will push a new ElementSetEntryPage onto the
         * Navigation stack with the selected item bound to it.
         */
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ElementSetEntryPage
                {
                    BindingContext = e.SelectedItem as ElementSet
                });
            }
        }

        /**
         * Associated Button's Text: "+"
         * 
         * Purpose: This method is called when the "+" icon in the ToolBar is
         * clicked. It pushes a new ElementSetEntryPage onto the Navigation stack
         * with a new instance of ElementSet bound to it.
         */
        async void OnElementSetAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ElementSetEntryPage
            {
                BindingContext = new ElementSet()
            });
        }

        /**
         * Associated Button's Text: "Select"
         * 
         * Purpose: When the user clicks on this button, a "SpeenWheelPage" is
         * initialized and pushed onto the Navigation stack for the user to view.
         * Additionally, the selected ElementSet is bound to this new
         * SpinWheelPage for its use.
         * 
         * However, before this is done, the method makes sure that the ElementSet
         * Has at least one or more Choices associated with it. If it does not have any,
         * an Alert is displayed, saying that the user has made an "Invalid
         * Selection", and that they either must try a different ElementSet or
         * populate the one they tried to select. After this message is displayed,
         * the method call ends, prohibiting them from continuing.
         */
        async void OnSelectButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            ElementSet elementSet = button.CommandParameter as ElementSet;

            // -=Checking to see if there are any files connected to the selected ElementSet=- //

            var files = Directory.EnumerateFiles(App.FolderPath, $"*.{elementSet.SetName}_choices.txt");

            if (!files.Any())
            {
                await DisplayAlert("Invalid Selection", "The selected ElementSet does not have any choices linked to it." +
                    "\n\nPlease either populate the selected ElementSet with choices or select a new one.", "OK");
                return; // This stops the user from continuing if they didn't enter any choices for the given ElementSet
            }

            if (elementSet != null)
            {
                await Navigation.PushAsync(new SpinWheelPage
                {
                    BindingContext = elementSet
                });
            }
        }
    }
}
