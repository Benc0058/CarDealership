using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Notifications;
using CarDealership.Catalog;

namespace CarDealership.Model
{
    public class Car
    {
        // Instance Field

        private int _id;
        private string _name;
        private string _brand;
        private string _color;
        private int _year;
        private string _comment;

        // Properties

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