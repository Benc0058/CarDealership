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
    [DataContract]
    public class Car
    {
        // Instance Field
        [DataMember]
        private int _id;
        [DataMember]
        private string _name;
        [DataMember]
        private string _brand;
        [DataMember]
        private string _color;
        [DataMember]
        private int _year;
        [DataMember]
        private string _comment;

        // Properties
        public Car(int id,string name, string brand,string color,int year,string comment)
        {
            _id = id;
            _name = name;
            _brand = brand;
            _color = color;
            _year = year;
            _comment = comment;
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
