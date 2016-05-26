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
        public ObservableCollection<Customer> CustomerCollection
        {
            set
            {
                _customerCollection = value;
                OnPropertyChanged();
            }
            get { return _customerCollection; }
        }
        private ObservableCollection<Car> _carCollection;
      
        public ObservableCollection<Car> CarCollection
        {
            set
            {
                _carCollection = value;
                OnPropertyChanged();
            }
            get { return _carCollection; }
        }
        public string name { set; get; }
        public int age { set; get; }
        public string adress { set; get; }
        public string phonenumber { set; get; }
        public string cpr { set; get; }
        public string license { set; get; }
        private Customer _selectedcustomer;
        public Customer selectedcustomer
        {
            set
            {
                if (value != _selectedcustomer)
                {
                    _selectedcustomer = value;
                    OnPropertyChanged("_selectedcustomer");
                }
            }
            get { return _selectedcustomer; }
        }
        private Car _selectedcar;
        public Car selectedcar
        {
            set
            {
                if (value != _selectedcar)
                {
                    _selectedcar = value;
                    OnPropertyChanged("_selectedcar");
                }
            }
            get { return _selectedcar; }
        }
        private string _invoicetext;
        public string invoicetext
        {
            set
            {
                if (value != _invoicetext)
                {
                    _invoicetext = value;
                    OnPropertyChanged("invoicetext");
           


                }
            }
            get { return _invoicetext; }
        }


        public string searchforcar { set; get; }
        public string searchforcustomer { set; get; }

        // Commands

        public Command addCustomer { set; get; }
        public Command createInvoice { set; get; }
        public Command searchCar { set; get; }
        public Command searchCustomer { set; get; }
        public Command deleteCar { set; get; }

        // Constructor

        public InvoiceViewModel()
        {
            invoicetext = "Select the customer and Press Create Invoice";
            //  _carCatalog = new CarCatalog();
            //invoicedetails = "Select a Car and a Customer\n Invoice details will display here";
            addCustomer = new Command(AddCustomer);
            createInvoice = new Command(CreateInvoice);
            searchCar = new Command(SearchCar);
            searchCustomer = new Command(SearchCustomer);
            CarCollection = CarCatalog._carList;
            CustomerCollection = CustomerCatalog._customerList;
        }

        // Methods
        
        public void SearchCar(object newItem)
        {
            CarCatalog.SearchCar(searchforcar);
        }
        public void SearchCustomer(object newItem)
        {
            CustomerCatalog.SearchCustomer(searchforcustomer);
        }
        public void CreateInvoice(object newItem)
        {
            if ((selectedcar!= null)&&(selectedcustomer != null))
            {
                Invoice invoice = new Invoice(selectedcar, selectedcustomer);
                invoicetext = invoice.Invoicetext();

            }

        }
        public void AddCustomer(object newItem)
        {
            //string cmdname = name;
            //int cmdage = age;
            //string cmdadress = adress;
            //string cmdphonenumber = phonenumber;
            //string cmdcpr = cpr;
            //string cmdlicense = license;

   
            if (Validate(name,age,adress,phonenumber,cpr,license))
            {
                Customer customer = CustomerCatalog.CreatNewCustomer(name,age,adress,phonenumber,cpr,license);
            }
            else
            {
                string k = "Missing data, all the information about customer must be filled out. Age must be a number";


                MessageBox.Show(k, "Missing data");
            }
        }
        public bool Validate(string name,int age, string adress,string phonenumber,string cpr, string license)
        {
            if (string.IsNullOrEmpty(name)) { return false; }
            if (string.IsNullOrEmpty(adress)) { return false; }
            if (string.IsNullOrEmpty(cpr)) { return false; }
            if (string.IsNullOrEmpty(license)) { return false; }
            if (string.IsNullOrEmpty(phonenumber)) { return false; }
            if (age == 0) { return false; }
           
            return true;
        }
    }

}

