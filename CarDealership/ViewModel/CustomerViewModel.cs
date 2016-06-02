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
                    OnPropertyChanged("");
               
                }
            }
            get { return _selectedcustomer; }
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
            //string cmdname = name;
            //int cmdage = age;
            //string cmdadress = adress;
            //string cmdphonenumber = phonenumber;
            //string cmdcpr = cpr;
            //string cmdlicense = license;


            if (Validate(Name, Age, Adress, PhoneNumber, Cpr, License))
            {
                Customer customer = CustomerCatalog.CreatNewCustomer(Name, Age, Adress, PhoneNumber, Cpr, License);
                _facade.SaveCustomer();
            }
            else
            {
                string k = "Missing data, all the information about customer must be filled out. Age must be a number";


                MessageBox.Show(k, "Missing data");
            }
        }

        public bool Validate(string name, int age, string adress, string phonenumber, string cpr, string license)
        {//todo change the validation 
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

