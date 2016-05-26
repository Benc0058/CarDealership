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
        public static void SearchCustomer(string text)
        {
            int k = 0;
            for (int i = 0; i < _customerList.Count; i++)
            {

                if (Convert.ToString(_customerList[i].Age) == text)
                {
                    replace(i, k); k++;
                }
                if (_customerList[i].Name == text)
                {
                    replace(i, k); k++;
                }
                if (_customerList[i].Address == text)
                {
                    replace(i, k); k++;
                }
                if (_customerList[i].PhoneNumber == text)
                {
                    replace(i, k); k++;
                }
                if (_customerList[i].CPRNumber == text)
                {
                    replace(i, k); k++;
                }
                if (_customerList[i].Licence == text)
                {
                    replace(i, k); k++;
                }
            }
        }

        private static void replace(int a, int b)
        {
            Customer customer = _customerList[a];
            _customerList[a] = _customerList[b];
            _customerList[b] = customer;
        }
    }
}
