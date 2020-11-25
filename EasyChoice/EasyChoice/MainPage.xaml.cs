using System;
using System.IO;
using Xamarin.Forms;

namespace EasyChoice
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "easychoice.txt");

        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                // implement
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // implement
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            // implement
        }
    }
}