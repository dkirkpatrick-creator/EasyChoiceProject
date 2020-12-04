using System;
using Xamarin.Forms;
using EasyChoice.Models;
using Xamarin.Forms.Xaml;

namespace EasyChoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoinFlipPage : ContentPage
    {
        public CoinFlipPage()
        {
            InitializeComponent();
        }

        async void OnFlipCoinButtonClicked(object sender, EventArgs e)
        {
            var coin = (Coin)BindingContext;

            coin.Flip();

            await DisplayAlert("You have flipped...", coin.ToString(), "OK");

            myLabel.Text = "You flipped: " + coin.ToString();
        }
    }
}