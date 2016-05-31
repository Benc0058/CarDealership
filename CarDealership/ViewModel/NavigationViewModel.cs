using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CarDealership.Interfaces;
using CarDealership.View;
using CarDealership.Persistency;

namespace CarDealership.ViewModel
{
    public class NavigationViewModel
    {
        // Properties

        public Command NavigateToCarCommand { set; get; }
        public Command NavigateToCustomer { set; get; }
        public Command LogOutCommand { set; get; }

        // Constructor

        public NavigationViewModel()
        {
            NavigateToCarCommand = new Command(GoCar);
            NavigateToCustomer = new Command(GoCustomer);
            LogOutCommand = new Command(LogOut);
        }

        //Commands

        public void GoCar(object obj)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame = new Frame();
            rootFrame.Navigate(typeof(RegisterCarPage)); // if u want to send the user data just , CurrentUser
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        public void GoCustomer(object obj)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame = new Frame();
            rootFrame.Navigate(typeof(CustomerPage)); // if u want to send the user data just ,CurrentUser
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        public void LogOut(object obj)
        {
            Facade a = new Facade();
            a.Save();
            a.SaveCustomer();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame = new Frame();
            rootFrame.Navigate(typeof(LoginPage)); // if u want to send the user data just , CurrentUser
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }
    }
}
