using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CarDealership.View;

namespace CarDealership.ViewModel
{
    class MenuViewModel
    {
        public Command ToRegisterCar { get; set; }
        public Command ToInvoce { get; set; }
    public MenuViewModel()
        {
            ToRegisterCar = new Command(NavigateCar);
            ToInvoce = new Command(NavigateInvoice);
        }
        public void NavigateCar(object newItem)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame = new Frame();
            rootFrame.Navigate(typeof(RegisterCar)); // if u want to send the user data just ,CurrentUser
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }
        public void NavigateInvoice(object newItem)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame = new Frame();
            rootFrame.Navigate(typeof(InvoiceView)); // if u want to send the user data just ,CurrentUser
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }
    }
}
