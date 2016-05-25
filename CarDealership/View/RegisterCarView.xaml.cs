using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarDealership.Catalog;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CarDealership.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterCar : Page
    {
        public RegisterCar()
        {
            this.InitializeComponent();
        }
        private void CarList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarCatalog.SelItem=CarList.SelectedIndex;
            CarCatalog._carList[CarList.SelectedIndex].Brand = "sdds";
        }

        private void SelChanged(object sender, RoutedEventArgs e)
        {
            textBlock.Text = Convert.ToString(CarCatalog._carList[CarList.SelectedIndex].ID);
            
        }
    }
}
