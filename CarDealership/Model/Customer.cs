using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class Customer
    {
        // Instance Field 

        private string _name;
        private int _age;
        private string _car;
        private string _address;
        private string _phoneNumber;
        private string _cprNumber;
        private string _licence;

        // Properties

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public int Age
        {
            set { _age = value; }
            get { return _age; }
        }

        public string Car
        {
            set { _car = value; }
            get { return _car; }
        }

        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }

        public string PhoneNumber
        {
            set { _phoneNumber = value; }
            get { return _phoneNumber; }
        }

        public string CPRNumber
        {
            set { _cprNumber = value; }
            get { return _cprNumber; }
        }

        public string Licence
        {
            set { _licence = value; }
            get { return _licence; }
        }

    }
}
