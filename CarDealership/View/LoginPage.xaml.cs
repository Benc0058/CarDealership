using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CarDealership.Model;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CarDealership.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();

            // Set the minimum size of the Application
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 720, Height = 720 });
        
            // Here we can change the color of the Title Bar
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            // Title Bar Content Area
            titleBar.BackgroundColor = Color.FromArgb(0, 50, 190, 166);
            titleBar.ForegroundColor = Colors.White;
 
            // Title Bar Button Area
            titleBar.ButtonBackgroundColor = Color.FromArgb(0, 50, 190, 166);
            titleBar.ButtonForegroundColor = Colors.White;
        }
    }
}
