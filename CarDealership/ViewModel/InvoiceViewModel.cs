using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Catalog;
using CarDealership.Interfaces;
using CarDealership.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CarDealership.ViewModel
{
    public class InvoiceViewModel : Notification
    {
        // Instance Field
        private ObservableCollection<Customer> _customerCollection;

        // Properties

        public ObservableCollection<Customer> CustomerCollection
        {
            set
            {
                _customerCollection = value;
                OnPropertyChanged();
            }
            get { return _customerCollection; }
        }

        public string name { set; get; }
        public int age { set; get; }

        public string adress { set; get; }

        public string phonenumber { set; get; }

        public string cpr { set; get; }

        public string license { set; get; }
        public Customer selectedcustomer { set; get; }
        public Car selectedcar { set; get; }

        // Commands

        public Command addCustomer { set; get; }
        public Command createInvoice { set; get; }

        // Constructor

        public InvoiceViewModel()
        {
            //  _carCatalog = new CarCatalog();

            addCustomer = new Command(AddCustomer);
            createInvoice = new Command(CreateInvoice);

            CustomerCollection = CustomerCatalog._customerList;
        }

        // Methods

        public void CreateInvoice(object newItem)
        {
            selectedcar = CarCatalog._carList[1];
            selectedcustomer = CustomerCatalog._customerList[1];
            Invoice newinvoice = new Invoice(selectedcar, selectedcustomer);
            newinvoice.printtofile();

        }
        public void AddCustomer(object newItem)
        {
            string cmdname = name;
            int cmdage = age;
            string cmdadress = adress;
            string cmdphonenumber = phonenumber;
            string cmdcpr = cpr;
            string cmdlicense = license;

            Customer customer = CustomerCatalog.CreatNewCustomer(cmdname, cmdage, cmdadress, cmdphonenumber, cmdcpr, cmdlicense);

        }
    }

}

