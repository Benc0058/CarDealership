﻿using System;
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
    class Invoice
    {
        private Customer _customer;
        private Car _car;

        public Invoice(Car car, Customer customer)
        {
            _customer = customer;
            _car = car;
        }
        public void printtofile()
        {
            string text = "";
            text = text + "fdfddffd";
        }
        public static string Invoicetext(Car car,Customer customer)
        {
            string text = "";
            text += "Invoice\n";
            text += "Car Information\n";
            text += "Name: " + car.Name+ "\n";
            text += "Brand : " + car.Brand + "\n";
            text += "Color : " + car.Color + "\n";
            text += "Year : " + Convert.ToString(car.Year) + "\n";
            

            text += "Customer Information\n";
            text += "Name : " + customer.Name + "\n";
            text += "Age : " + customer.Age + "\n";
            text += "Adress : " + customer.Address + "\n";
            text += "Phone number : " + Convert.ToString(customer.PhoneNumber) + "\n";
            text += "CPR number : " + Convert.ToString(customer.CPRNumber) + "\n\n";
           // text += "Price without tax :" + Convert.ToString(0.8 * car.Price) + " dkk\n";
            text += "Price with tax :" + Convert.ToString(car.Price) + " dkk\n\n";
            text += "Date : " + DateTime.Now.ToString("dd:mm:yy")+ "\n";
            text += "Sold by Bence";
            return text;


        }
        public async void Save(string text)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync("invoice.txt", CreationCollisionOption.ReplaceExisting);
            Stream stream = await file.OpenStreamForWriteAsync();
            using (StreamWriter writetext = new StreamWriter(stream))
            {
                writetext.WriteLine(text);
            }

        }
    }
}