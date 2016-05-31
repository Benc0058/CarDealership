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
        private string _adress;
        private string _phoneNumber;
        private string _cprNumber;
        private string _licence;

        // Properties
        public Customer(string name, int age, string adress, string phonenumber, string cpr, string license)
        {
            _name = name;
            _age = age;
            _adress = adress;
            _phoneNumber = phonenumber;
            _cprNumber = cpr;
            _licence = license;
        }
        public Customer()
        {

        }
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

        public string Adress
        {
            set { _adress = value; }
            get { return _adress; }
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

        public string License
        {
            set { _licence = value; }
            get { return _licence; }
        }

    }
}