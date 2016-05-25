using System;
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
        static public int SelItem = -1;
        static public ObservableCollection<Car> _carList = new ObservableCollection<Car>();

        // Method
        static public Car CreatNewCar(string name, string brand, string color, int year, string comment, int price)
        {
            Car car = new Car(name, brand, color, year, comment, price);
            //if (ListContains(car)) { car = null; }
            //else
            //{
            _carList.Add(car);
            //}

            return car;

        }
        private static bool ListContains(Car car)
        {
            bool contains = false;
            foreach (Car i in _carList)
            {
                if (i.Equals(car)) { contains = false; break; }
            }
            return contains;
        }
    }
}