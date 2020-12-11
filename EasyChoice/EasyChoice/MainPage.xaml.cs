// Authors: Christian Cox & Kyle Daniel Kirkpatrick

using EasyChoice.Models;
using System;
using Xamarin.Forms;

namespace EasyChoice
{
    // The MainPage represents the "Main Menu" page for the app;
    // this is the first page that the user sees when they open the app
    public partial class MainPage : ContentPage
    {
        // Default constructor
        public MainPage()
        {
            InitializeComponent();
        }

        /**
         * Associated Button's Text: "Flip a Coin"
         * 
         * Purpose: When the user clicks on this button, a "CoinFlipPage" is initialized and
         * pushed onto the Navigation stack for the user to view. Additionally a new Coin
         * object is created and bound to this new CoinFlipPage for its use.
         */
        async void OnFlipButtonClicked(object sender, EventArgs e)
        {
            // First checking to make sure that the button pressed was indeed the one we wanted
            // the user to press
            string myOutput = "Flip a Coin";
            Debug.Debug.Assert((sender as Button).Text.Equals(myOutput));

            // Then creating a new CoinFlipPage and binding a new Coin instance to it
            await Navigation.PushAsync(new CoinFlipPage
            {
                BindingContext = new Coin()
            });
        }

        /**
         * Associated Button's Text: "Spin a Wheel"
         * 
         * Purpose: When the user clicks on this button, an "ElementSetPage" is initialized and
         * pushed onto the Navigation stack for the user to view.
         */
        async void OnSpinButtonClicked(object sender, EventArgs e)
        {
            // First checking to make sure that the button pressed was indeed the one we wanted
            // the user to press
            string myOutput = "Spin a Wheel";
            Debug.Debug.Assert((sender as Button).Text.Equals(myOutput));

            await Navigation.PushAsync(new ElementSetPage());
        }
    }
}