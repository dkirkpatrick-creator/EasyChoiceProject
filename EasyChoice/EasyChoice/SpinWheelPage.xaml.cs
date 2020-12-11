// Authors: Christian Cox & Kyle Daniel Kirkpatrick

using System;
using Xamarin.Forms;
using EasyChoice.Models;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.IO;

namespace EasyChoice
{
    // The SpinWheelPage is a page where the user can press a button to spin
    // a Wheel of varying inputs
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpinWheelPage : ContentPage
    {
        // Default constructor
        public SpinWheelPage()
        {
            InitializeComponent();
        }

        /**
         * Associated Button's Text: "Spin the Wheel!"
         * 
         * Purpose: When the user clicks on this button, an instance of Wheel is
         * spun, and a random Choice is selected from the Wheel. Next, a DisplayAlert
         * pops up, showing the user what the Wheel "landed upon". Finally, a label is
         * initialized showing the user's result.
         */
        async void OnSpinWheelButtonClicked(object sender, EventArgs e)
        {
            // The current ElementSet that holds all of the choices
            var elementSet = (ElementSet)BindingContext;

            // Checking to make sure that the ElementSet that has been selected isn't null
            Debug.Debug.Assert(elementSet != null);

            // The list that will hold all of our choices
            var choices = new List<Choice>();

            // Every "choice" file that is linked to the current elementSet
            var files = Directory.EnumerateFiles(App.FolderPath, $"*.{elementSet.SetName}_choices.txt");
            foreach (var filename in files)
            {
                choices.Add(new Choice
                {
                    Filename = filename,
                    Name = File.ReadAllText(filename)
                });
            }

            Wheel wheel = new Wheel(choices);

            Choice randChoice = wheel.Spin();

            // Checking to make sure that Wheel has been spun and that randChoice
            // has been assigned a value
            Debug.Debug.Assert(randChoice != null);

            await DisplayAlert("The wheel landed upon...", randChoice.ToString(), "OK");

            myLabel.Text = "The wheel landed upon: " + randChoice.ToString();
        }
    }
}