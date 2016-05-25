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
