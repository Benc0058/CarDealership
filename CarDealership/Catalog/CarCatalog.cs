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
using CarDealership.Persistency;

namespace CarDealership.Catalog
{
    static public class CarCatalog
    {
        // Instance Field

        static public ObservableCollection<Car> _carList = new ObservableCollection<Car>();
        static public Car SelectedCar;
        // Method
        static public Car CreatNewCar(string name, string brand, string color, string year, string comment, string price, string imagepath)
        {
            Car car = new Car(name, brand, color, year, comment, price, imagepath);
            //if (ListContains(car)) { car = null; }
            //else
            //{
            _carList.Add(car);
            //}

            return car;

        }

    

        public static void SearchCar(string text)
        {
            int k = 0;
            for (int i = 0; i < _carList.Count; i++)
            {
                if (Convert.ToString(_carList[i].ID) == text)
                {
                    replace(i, k); k++;
                }
                if (Convert.ToString(_carList[i].Year) == text)
                {
                    replace(i, k); k++;
                }
                if (Convert.ToString(_carList[i].Price) == text)
                {
                    replace(i, k); k++;
                }
                if (_carList[i].Name == text)
                {
                    replace(i, k); k++;
                }
                if (_carList[i].Brand == text)
                {
                    replace(i, k); k++;
                }
                if (_carList[i].Comment == text)
                {
                    replace(i, k); k++;
                }
                if (_carList[i].Color == text)
                {
                    replace(i, k); k++;
                }
            }
        }

        private static void replace(int a, int b)
        {
            Car car = _carList[a];
            _carList[a] = _carList[b];
            _carList[b] = car;
        }
    }
}