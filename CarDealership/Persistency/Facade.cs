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

namespace CarDealership.Persistency
{
    public class Facade
    {
        private ObservableCollection<Car> _listOfCars;
        private static string filename = "ListOfCar.txt";

        public async void Save(ObservableCollection<Car> carCatalog)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Car>));

            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                xmlSerializer.Serialize(stream, carCatalog);
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
            return _listOfCars;
        }

    }
}
