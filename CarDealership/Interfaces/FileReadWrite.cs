using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CarDealership.Model;
using CarDealership.Catalog;


namespace CarDealership.Interfaces
{
    class FileReadWrite
    {

        #region ModelData methods "Object Graphs"
        private List<Car> buildObjectGraph()
        {
            var myCars = CarCatalog._carList;
            return myCars;
        }
        #endregion

        #region Instance Fields
        //Used by XML helper methods
        private const string XMLFILENAME = "data.xml";

        //used by JSON helper methods
        private const string JSONFILENAME = "data.json";
        #endregion

        #region XML helper methods
        public async Task writeXMLAsync()
        {
            var myCars = buildObjectGraph();

            var serializer = new DataContractSerializer(typeof(List<Car>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                              XMLFILENAME,
                              CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, myCars);
            }

        
        }

        public async Task readXMLAsync()
        {
            string content = String.Empty;

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(XMLFILENAME);
            using (StreamReader reader = new StreamReader(myStream))
            {
                content = await reader.ReadToEndAsync();
            }

          
        }
        #endregion

        #region JSON helper methods
        public async Task writeJsonAsync()
        {
            // Notice that the write is ALMOST identical ... except for the serializer.

            var myCars = buildObjectGraph();

            var serializer = new DataContractJsonSerializer(typeof(List<Car>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                          JSONFILENAME,
                          CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, myCars);
            }

           
        }

        public async Task readJsonAsync()
        {
            // Notice that the write **IS** identical ... except for the serializer.

            string content = String.Empty;

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
            using (StreamReader reader = new StreamReader(myStream))
            {
                content = await reader.ReadToEndAsync();
            }

            
        }
        #endregion

        #region object graph JSON
        public async Task deserializeJsonAsync()
        {
            string content = String.Empty;

            List<Car> myCars;
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<Car>));

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);

            myCars = (List<Car>)jsonSerializer.ReadObject(myStream);
//
           // foreach (var car in myCars)
           // {
            //    content += String.Format("ID: {0}, Make: {1}, Model: {2} ... ", car.Id, car.Make, car.Model);
           // }

           
        }
        #endregion
    }
}
