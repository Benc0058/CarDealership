using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using CarDealership.Model;
namespace CarDealership.Model
{
    public class Invoice
    {

        // Instance Field

        private Customer _customer;
        private Car _car;
        public string invoicetext;
        static public string loggedinuser;
      
        // COnstructor

        public Invoice(Car car, Customer customer)
        {
            _customer = customer;
            _car = car;
            invoicetext = Invoicetext();

        }

        // Properties

        public string Invoicetext()
        {
            Car car = this._car;
            Customer customer = this._customer;
            string text = "";
            text += "Invoice\n";
            text += "Car Information\n";
            text += "Name: " + car.Name + "\n";
            text += "Brand : " + car.Brand + "\n";
            text += "Color : " + car.Color + "\n";
            text += "Year : " + Convert.ToString(car.Year) + "\n";


            text += "Customer Information\n";
            text += "Name : " + customer.Name + "\n";
            text += "Age : " + customer.Age + "\n";
            text += "Adress : " + customer.Adress + "\n";
            text += "Phone number : " + Convert.ToString(customer.PhoneNumber) + "\n";
            text += "CPR number : " + Convert.ToString(customer.CPRNumber) + "\n\n";
            // text += "Price without tax :" + Convert.ToString(0.8 * car.Price) + " dkk\n";
            text += "Price with tax :" + Convert.ToString(car.Price) + "\n\n";
            text += "Date : " + DateTime.Now.ToString("d") + "\n";
            text += "Sold by "+loggedinuser;
            return text;


        }
    }
}