using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Catalog;
using CarDealership.Interfaces;
using CarDealership.Model;
using Windows.UI.Xaml.Controls;


namespace CarDealership.ViewModel
{
    public class RegisterCarViewModel : Notification
    {
        // Instance Field
        private ObservableCollection<Car> _carCollection;

        // Properties

        public ObservableCollection<Car> CarCollection
        {
            set
            {
                _carCollection = value;
                OnPropertyChanged();
            }
            get { return _carCollection; }
        }

        public int ID { set; get; }

        public string Name { set; get; }

        public string Brand { set; get; }

        public string Color { set; get; }

        public int Year { set; get; }

        public string Comment { set; get; }

        // Commands

        public Command AddCar { set; get; }
        public Command Switchpage { set; get; }
        public Command Save { get; set; }

        // Constructor

        public RegisterCarViewModel()
        {
          //  _carCatalog = new CarCatalog();

            AddCar = new Command(DoCommand);
            Switchpage = new Command(Switch);
            Save = new Command(SaveIT);
        

            CarCollection = new ObservableCollection<Car>();
        }

        // Methods
        public void SaveIT(object item)
        {
            CarCatalog.SaveList();
        }

        public void Switch(object Item)
        {
          
        }
        public void DoCommand(object newItem)
        {
            int cmdId = ID;
            string cmdName = Name;
            string cmdBrand = Brand;
            string cmdColor = Color;
            int cmdYear = Year;
            string cmdComment = Comment;

            Car car = CarCatalog.CreatNewCar(cmdId, cmdName, cmdBrand, cmdColor, cmdYear, cmdComment);

            CarCollection.Add(car);

        }
    }
}
