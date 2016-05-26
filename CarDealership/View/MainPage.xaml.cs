using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CarDealership.Interfaces;
using CarDealership.Persistency;
using CarDealership.Catalog;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CarDealership.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string username;
        Facade loading = new Facade();
        public MainPage()
        {
            this.InitializeComponent();
            
            loading.Load();

        }


        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            framemain.Navigate(typeof(InvoiceView));
        }
        private void Registercar_Click(object sender, RoutedEventArgs e)
        {
            framemain.Navigate(typeof(RegisterCar));
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
            loading.Save();
        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            framemain.Navigate(typeof(InvoiceView));
        }
    }
}