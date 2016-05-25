using System;
using System.Collections.Generic;
using CarDealership.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CarDealership.Catalog
{
    static public class CustomerCatalog
    {
        // Instance Field
        static public ObservableCollection<Customer> _customerList = new ObservableCollection<Customer>();

        // Method
        static public Customer CreatNewCustomer(string name, int age, string adress, string phonenumber, string cpr, string license)
        {
            Customer customer = new Customer(name, age, adress, phonenumber, cpr, license);

            _customerList.Add(customer);

            return customer;

        }
    }
}
