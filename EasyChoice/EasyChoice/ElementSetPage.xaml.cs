﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using EasyChoice.Models;
using Xamarin.Forms.Xaml;

namespace EasyChoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElementSetPage : ContentPage
    {
        public ElementSetPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var elementSets = new List<ElementSet>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.elementSets.txt");
            foreach (var filename in files)
            {
                elementSets.Add(new ElementSet
                {
                    Filename = filename,
                    SetName = File.ReadAllText(filename)
                });
            }

            // could modify these so that they're listed by date instead
            listView.ItemsSource = elementSets
                .OrderBy(d => d.SetName)
                .ToList();
        }

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

        async void OnElementSetAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ElementSetEntryPage
            {
                BindingContext = new ElementSet()
            });
        }

        async void OnSelectButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            ElementSet elementSet = button.CommandParameter as ElementSet;

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