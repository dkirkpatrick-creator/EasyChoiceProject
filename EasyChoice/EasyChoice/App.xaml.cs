// Authors: Christian Cox & Kyle Daniel Kirkpatrick

using System;
using System.IO;
using Xamarin.Forms;

namespace EasyChoice
{
    // This class is the core of the project; it sets the root page
    // (i.e. the first page that we see when we start up the app) and
    // additionally sets some global variables needed throughout the app
    public partial class App : Application
    {
        // The folderpath of this app on the given phone
        public static string FolderPath { get; private set; }

        // The default constructor; this is called when we start the app
        public App()
        {
            InitializeComponent();

            // Setting the FolderPath of the App on the given phone
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            // Displaying the MainPage for the user to view
            MainPage = new NavigationPage(new MainPage());
        }

        // Can override this method if wanted; as of now it serves no purpose.
        // However, we are going to leave it just in case we need it for future use.
        protected override void OnStart()
        {
        }

        // Can override this method if wanted; as of now it serves no purpose.
        // However, we are going to leave it just in case we need it for future use.
        protected override void OnSleep()
        {
        }

        // Can override this method if wanted; as of now it serves no purpose.
        // However, we are going to leave it just in case we need it for future use.
        protected override void OnResume()
        {
        }
    }
}
