using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    class Invoice
    {
        private Customer _customer;
        private Car _car;

        public Invoice(Car car,Customer customer)
        {
            _customer = customer;
            _car = car;
        }
    }
}
