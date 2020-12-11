// Authors: Christian Cox & Kyle Daniel Kirkpatrick

using System;
using Xamarin.Forms;
using EasyChoice.Models;
using Xamarin.Forms.Xaml;

namespace EasyChoice
{
    // The CoinFlipPage is a page where a user can press a button to flip a Coin

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoinFlipPage : ContentPage
    {
        // Default constructor
        public CoinFlipPage()
        {
            InitializeComponent();
        }

        /**
         * Associated Button's Text: "Flip the Coin!"
         * 
         * Purpose: When the user clicks on this button, an instance of Coin is
         * "flipped" (i.e. a random value of either "HEADS" or "TAILS" is assigned
         * to the Coin's Value property) and a DisplayAlert pops up showing the user
         * what the Coin "landed upon". Additionally, a label is initialized
         * showing the user's result.
         */
        async void OnFlipCoinButtonClicked(object sender, EventArgs e)
        {
            var coin = (Coin)BindingContext;

            coin.Flip();

            // Checking to make sure that the coin was flipped, now having
            // a Value of either "HEADS" or "TAILS"
            Debug.Debug.Assert(coin.Value.Equals(Coin.CoinValue.HEADS) || coin.Value.Equals(Coin.CoinValue.TAILS));

            await DisplayAlert("You have flipped...", coin.ToString(), "OK");

            myLabel.Text = "You flipped: " + coin.ToString();
        }
    }
}