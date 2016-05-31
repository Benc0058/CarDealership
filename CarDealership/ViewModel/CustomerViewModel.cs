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
    public class CustomerViewModel : Notification
    {
        // Instance Field
        private ObservableCollection<Customer> _customerCollection;
    
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

        

        public string name { set; get; }

        public int age { set; get; }

        public string adress { set; get; }

        public string phonenumber { set; get; }

        public string cpr { set; get; }

        public string license { set; get; }

        public Customer Selectedcustomer
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

      

  

     

        public string searchforcustomer { set; get; }

        public Command addCustomer { set; get; }
      
        public Command searchCustomer { set; get; }
        public Command deleteCustomer { set; get; }

        // Constructor

        public CustomerViewModel()
        {
           
            addCustomer = new Command(AddCustomer);
  
           
            searchCustomer = new Command(SearchCustomer);
      //todo load customer facade here
            CustomerCollection = CustomerCatalog._customerList;
        }

        // Commands

    

        public void SearchCustomer(object newItem)
        {
            CustomerCatalog.SearchCustomer(searchforcustomer);
        }

 

        public void AddCustomer(object newItem)
        {
            //string cmdname = name;
            //int cmdage = age;
            //string cmdadress = adress;
            //string cmdphonenumber = phonenumber;
            //string cmdcpr = cpr;
            //string cmdlicense = license;


            if (Validate(name, age, adress, phonenumber, cpr, license))
            {
                Customer customer = CustomerCatalog.CreatNewCustomer(name, age, adress, phonenumber, cpr, license);
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
    }

}

