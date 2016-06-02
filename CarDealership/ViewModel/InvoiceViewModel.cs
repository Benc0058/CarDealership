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
using CarDealership.Persistency;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CarDealership.ViewModel
{
    public class InvoiceViewModel : Notification
    {
        // Instance Field
        private ObservableCollection<Customer> _customerCollection;
        private ObservableCollection<Car> _carCollection;
        private Customer _selectedcustomer;
        private Car _selectedcar;
        private Facade _facade;
        private string _invoicetext;

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

        public Invoice thisinvoice { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public string Adress { set; get; }
        public string PhoneNumber { set; get; }
        public string Cpr { set; get; }
        public string License { set; get; }
        public Customer SelectedCustomer
        {
            set
            {
                if (value != _selectedcustomer)
                {
                    _selectedcustomer = value;
                    OnPropertyChanged("SelectedCustomer");
                    CreateInvoice("sd");
                }
            }
            get { return _selectedcustomer; }
        }
        public string Invoicetext
        {
            set
            {
                if (value != _invoicetext)
                {
                    _invoicetext = value;
                    OnPropertyChanged("Invoicetext");



                }
            }
            get { return _invoicetext; }
        }

        private string searchforcustomer;
        public string SearchForCustomer

        {
            set
            {
                searchforcustomer = value;
                OnPropertyChanged("SearchForCustomer");
                SearchCustomer("sd");
            }

            get { return searchforcustomer; }
        }


        public Command createInvoice { set; get; }
        public Command searchCustomer { set; get; }

        // Constructor

        public InvoiceViewModel()
        {
            Invoicetext = "Select the customer to show Invoice details";
            //  _carCatalog = new CarCatalog();
            //invoicedetails = "Select a Car and a Customer\n Invoice details will display here";
            createInvoice = new Command(CreateInvoice);
          
            searchCustomer = new Command(SearchCustomer);


            _facade = new Facade();
            LoadData();
            CustomerCollection = CustomerCatalog._customerList;

        }

        // Commands

   

        public void SearchCustomer(object newItem)
        {
            if (string.IsNullOrEmpty(searchforcustomer))
            {
                CustomerCollection = CustomerCatalog._customerList;
            }
            else
            {
                CustomerCollection = CustomerCatalog.SearchCustomer(searchforcustomer);
            }


        }

        public void FinalizeSale(object newItem)
        {
            if (thisinvoice != null)
            {
                CarCatalog._carList.Remove(CarCatalog.SelectedCar);
            }
            //print to file
            //add to the user

        }

        public void CreateInvoice(object newitem)
        {
            if (SelectedCustomer != null)
            {
                Invoice invoice = new Invoice(CarCatalog.SelectedCar, SelectedCustomer);
                thisinvoice = invoice;
                Invoicetext = invoice.invoicetext;
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


            if (Validate(Name, Age, Adress, PhoneNumber, Cpr, License))
            {
                Customer customer = CustomerCatalog.CreatNewCustomer(Name, Age, Adress, PhoneNumber, Cpr, License);
            }
            else
            {
                string k = "Missing data, all the information about customer must be filled out. Age must be a number";


                MessageBox.Show(k, "Missing data");
            }
        }

        public bool Validate(string name, int age, string adress, string phonenumber, string cpr, string license)
        {
            if (string.IsNullOrEmpty(name)) { return false; }
            if (string.IsNullOrEmpty(adress)) { return false; }
            if (string.IsNullOrEmpty(cpr)) { return false; }
            if (string.IsNullOrEmpty(license)) { return false; }
            if (string.IsNullOrEmpty(phonenumber)) { return false; }
            if (age == 0) { return false; }

            return true;
        }
        public async void LoadData()
        {
            try
            {
                ObservableCollection<Customer> customer = await _facade.LoadCustomer();

                this._customerCollection = customer;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is: " + ex, "Error");
            }
        }
    }

}