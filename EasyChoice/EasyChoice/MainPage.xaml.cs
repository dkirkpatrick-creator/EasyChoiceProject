using EasyChoice.Models;
using System;
using System.IO;
using Xamarin.Forms;

namespace EasyChoice
{
    public partial class MainPage : ContentPage
    {
        //string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "easychoice.txt");

        public MainPage()
        {
            InitializeComponent();

            //if (File.Exists(_fileName))
            //{
            //    // implement
            //}
        }

        async void OnFlipButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoinFlipPage
            {
                BindingContext = new Coin()
            });
        }

        void OnSpinButtonClicked(object sender, EventArgs e)
        {
            // implement
        }
    }
}