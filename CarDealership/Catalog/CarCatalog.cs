using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;
using CarDealership.ViewModel;

namespace CarDealership.Catalog
{
    public class CarCatalog
    {
        // Instance Field
        private List<Car> _carList;

        // Method
        public Car CreatNewCar(int id, string name, string brand, string color, int year, string comment)
        {
            _carList = new List<Car>();

            Car car = new Car() { ID = id, Name = name, Brand = brand, Color = color, Year = year, Comment = comment };
            
            _carList.Add(car);

            return car;

        }
    }
}
