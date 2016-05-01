using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;

namespace CarDealership.Catalog
{
    public class CarCatalog : Car
    {
        private ObservableCollection<Car> _carList; 

        // List
        public ObservableCollection<Car> Carlist
        {
             set { this._carList = value; }
             get { return _carList; }
        }
         
        // Method
        public void AddCar(Car Name)
        {
            Carlist.Add(Name);
        } 

        // Constructor
        public CarCatalog()
        {
            
        }


    }
}
