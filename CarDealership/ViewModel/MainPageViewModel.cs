using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CarDealership.Interfaces;
using CarDealership.Model;
using CarDealership.Persistency;
using CarDealership.View;
namespace CarDealership.ViewModel
{
    class MainPageViewModel
    {
        public Frame littleframe {get;set;}
        public Command ToInvoicePage { get; set; }
    public MainPageViewModel()
        {
          
        }
    public void NavigateToInvoice(object newItem)
        {
            //Frame rootFrame = Window.Current.Content as Frame;
            //if (rootFrame.Content == null)
            //{
         
            littleframe.Navigate(typeof(InvoiceView));
            //Window.Current.Content = rootFrame;
            //Window.Current.Activate();
        }
    }
}
