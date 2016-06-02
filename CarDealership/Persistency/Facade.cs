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
using CarDealership.Catalog;

namespace CarDealership.Persistency
{
    public class Facade
    {
        private ObservableCollection<Car> _listOfCars;
        private ObservableCollection<Customer> _listOfCustomers;
        private static string filename = "ListOfCar.txt";
        private static string filenamecustomer = "ListOfCustomer.txt";

        public async void Save()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Car>));

            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                xmlSerializer.Serialize(stream, CarCatalog._carList);

            }
        }

        public async Task<ObservableCollection<Car>> Load()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.GetFileAsync(filename);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Car>));

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                _listOfCars = xmlSerializer.Deserialize(stream) as ObservableCollection<Car>;

            }
            CarCatalog._carList = _listOfCars;
            return _listOfCars;
        }

        // Serializer to Customer

        public async void SaveCustomer()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(filenamecustomer, CreationCollisionOption.ReplaceExisting);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Customer>));

            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                xmlSerializer.Serialize(stream, CustomerCatalog._customerList);

            }
        }
        public async Task<ObservableCollection<Customer>> LoadCustomer()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.GetFileAsync(filenamecustomer);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Customer>));

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                _listOfCustomers = xmlSerializer.Deserialize(stream) as ObservableCollection<Customer>;

            }
            CustomerCatalog._customerList = _listOfCustomers;
            return _listOfCustomers;
        }

    }
}