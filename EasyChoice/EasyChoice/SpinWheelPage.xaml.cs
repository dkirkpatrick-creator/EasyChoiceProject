using System;
using Xamarin.Forms;
using EasyChoice.Models;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.IO;

namespace EasyChoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpinWheelPage : ContentPage
    {
        public SpinWheelPage()
        {
            InitializeComponent();
        }

        async void OnSpinWheelButtonClicked(object sender, EventArgs e)
        {
            var elementSet = (ElementSet)BindingContext; // the current elementSet that holds all of the choices

            var choices = new List<Choice>(); // the list that will hold all of our choices

            var files = Directory.EnumerateFiles(App.FolderPath, $"*.{elementSet.SetName}_choices.txt"); // every "choice" file that is linked to the current elementSet
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

            await DisplayAlert("The wheel landed upon...", randChoice.ToString(), "OK");

            myLabel.Text = "The wheel landed upon: " + randChoice.ToString();
        }
    }
}