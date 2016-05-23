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
    class UserFacade
    {
        private ObservableCollection<User> _listofUsers;
        private static string filename = "Users.txt";

        public async void Save(ObservableCollection<User> users)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<User>));

            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                xmlSerializer.Serialize(stream, users);
            }
        }

        public async Task<ObservableCollection<User>> Load()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.GetFileAsync(filename);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (ObservableCollection<User>));

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                _listofUsers = xmlSerializer.Deserialize(stream) as ObservableCollection<User>;
            }
            return _listofUsers;
        }
    }
}
