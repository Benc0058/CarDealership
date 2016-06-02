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
    public class CustomerViewModel : Notification
    {
        // Instance Field

        private ObservableCollection<Customer> _customerCollection;
        private Facade _facade;
        private Customer _selectedcustomer;
        private string searchforcustomer;

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

        public string Name { set; get; }

        public string Age { set; get; }

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
                    OnPropertyChanged("");
               
                }
            }
            get { return _selectedcustomer; }
        }

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
        

        public Command AddCustomerCommand { set; get; }
        public Command SearchCustomerCommand { set; get; }
        public Command DeleteCustomerCommand { set; get; }

        // Constructor

        public CustomerViewModel()
        {

            AddCustomerCommand = new Command(AddCustomer);
            SearchCustomerCommand = new Command(SearchCustomer);
            DeleteCustomerCommand = new Command(DeleteCustomer);

            _facade = new Facade();
            LoadData();
            CustomerCollection = CustomerCatalog._customerList;
        }

        // Commands

        public void DeleteCustomer(object newItem)
        {
            CustomerCatalog._customerList.Remove(SelectedCustomer);
            _facade.SaveCustomer();
        }

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

        public void AddCustomer(object newItem)
        {

            if (Validate(Name, Age, Adress, PhoneNumber, Cpr, License)=="true")
            {
                Customer customer = CustomerCatalog.CreatNewCustomer(Name, Int32.Parse(Age), Adress, PhoneNumber, Cpr, License);
                _facade.SaveCustomer();
            }
            else
            {
                MessageBox.Show((Validate(Name, Age, Adress, PhoneNumber, Cpr, License)), "Missing data");
            }
        }

        public string Validate(string name, string age, string adress, string phone, string cpr,string license)
        {
            if (string.IsNullOrEmpty(name)) { return "Name is empty"; }
            if (string.IsNullOrEmpty(age)) { return "Age is empty"; }
            if (string.IsNullOrEmpty(Adress)) { return "Adress is empty"; }
            if (string.IsNullOrEmpty(phone)) { return "Phone Number is empty"; }
            if (string.IsNullOrEmpty(cpr)) { return "CPR is empty"; }
            if (string.IsNullOrEmpty(license)) { return "License is empty"; }
            try
            {
                int x = Int32.Parse(age);
                if ((x < 18) || (x > 150))
                {
                    return "Invalid Age";
                }
            }
            catch
            {
                return "Age Must Be a Number";
            }
            try
            {
                int x = Int32.Parse(cpr);
               
            }
            catch
            {
                return "CPR Must Be a Number";
            }
            return "true";
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

