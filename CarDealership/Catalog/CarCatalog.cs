﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;
using CarDealership.ViewModel;
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

namespace CarDealership.Catalog
{
    static public class CarCatalog
    {
        // Instance Field
        static public List<Car> _carList = new List<Car>();

        // Method
        static public Car CreatNewCar(int id, string name, string brand, string color, int year, string comment)
        {
            Car car = new Car(id, name, brand, color, year, comment);

            _carList.Add(car);

            return car;

        }
        static public async void SaveList()
        {
          await writeJsonAsync();
        }
        #region ModelData methods "Object Graphs"
        static private List<Car> buildObjectGraph()
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
        static public async Task writeXMLAsync()
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

        static public async Task readXMLAsync()
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
        static public async Task writeJsonAsync()
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

       static public async Task readJsonAsync()
        {
            // Notice that the write **IS** identical ... except for the serializer.

            string content = String.Empty;

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
            using (StreamReader reader = new StreamReader(myStream))
            {
                content = await reader.ReadToEndAsync();
            }


        }
      
        static public async Task deserializeJsonAsync()
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
