using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;

namespace CarDealership.Catalog
{
    public class CustomerCatalog
    {
        // Instance Field

        private List<Customer> _customerList;

        // Method
        public Customer CreatInvoice(int name, string age, string car, string address, int phone, string cpr, string licence, string tax, int price)
        {
            _customerList = new List<Customer>();

            Customer customer = new Customer(); { };

            _customerList.Add(customer);

            return customer;

        }
    }
}
