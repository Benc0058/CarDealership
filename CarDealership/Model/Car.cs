using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using CarDealership.Catalog;
using System.Runtime.Serialization;

namespace CarDealership.Model
{

    public class Car
    {
        // Instance Field
       public static int idCount = 0;
        private int _id;
        private string _name;
        private string _brand;
        private string _color;
        private int _year;
        private string _comment;
        private int _price;
        // Constructor. It is not good to use the default Constructor because the data will be missing
        public Car(string name, string brand, string color, int year, string comment, int price)
        {
            idCount++;
            _id = idCount;
            _name = name;
            _brand = brand;
            _color = color;
            _year = year;
            _comment = comment;
            _price = price;
        }
        public Car()
        {

        }
        // Properties
        public int Price
        {
            set { _price = value; }
            get { return _price; }
        }
        public int ID
        {
            set { this._id = value; }
            get { return _id; }
        }

        public string Name
        {
            set { this._name = value; }
            get { return _name; }
        }

        public string Brand
        {
            set { this._brand = value; }
            get { return _brand; }
        }

        public string Color
        {
            set { this._color = value; }
            get { return _color; }
        }

        public int Year
        {
            set { this._year = value; }
            get { return _year; }
        }

        public string Comment
        {
            set { this._comment = value; }
            get { return _comment; }
        }
    }
}
