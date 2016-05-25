﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CarDealership.Catalog;
using CarDealership.Model;
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
    public sealed partial class InvoiceView : Page
    {
        public InvoiceView()
        {
            this.InitializeComponent();
        }
        private void SelChanged(object sender, RoutedEventArgs e)
        {
            if (CarList.SelectedIndex != -1)
            {
                Car car = CarCatalog._carList[CarList.SelectedIndex];
                Customer customer = CustomerCatalog._customerList[CustomerList.SelectedIndex];
                textBlock.Text = Invoice.Invoicetext(car, customer);
            }
        }
        private void SelChangedCustomer(object sender, RoutedEventArgs e)
        {
            if (CarList.SelectedIndex != -1)
            {
                Car car = CarCatalog._carList[CarList.SelectedIndex];
                Customer customer = CustomerCatalog._customerList[CustomerList.SelectedIndex];
                textBlock.Text = Invoice.Invoicetext(car, customer);
            }
        }
    }
}