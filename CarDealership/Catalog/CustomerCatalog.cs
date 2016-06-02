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

        // Methods

        static public Customer CreatNewCustomer(string name, int age, string adress, string phonenumber, string cpr, string license)
        {
            Customer customer = new Customer(name, age, adress, phonenumber, cpr, license);

            _customerList.Add(customer);

            return customer;
        }

        public static ObservableCollection<Customer> SearchCustomer(string text)
        {
            ObservableCollection<Customer> k = new ObservableCollection<Customer>();
            for (int i = 0; i < _customerList.Count; i++)
            {

                if (Convert.ToString(_customerList[i].Age) == text)
                {
                    k.Add(_customerList[i]); continue;
                }
                if (_customerList[i].Name == text)
                {
                    k.Add(_customerList[i]); continue;
                }
                if (_customerList[i].Adress == text)
                {
                    k.Add(_customerList[i]); continue;
                }
                if (_customerList[i].PhoneNumber == text)
                {
                    k.Add(_customerList[i]); continue;
                }
                if (_customerList[i].CPRNumber == text)
                {
                    k.Add(_customerList[i]); continue;
                }
                if (_customerList[i].License == text)
                {
                    k.Add(_customerList[i]); continue;
                }
            }
            return k;
        }
    }
}
