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
using System.Runtime.Serialization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CarDealership.Persistency;

namespace CarDealership.ViewModel
{
    public class RegisterCarViewModel : Notification
    {
        // Instance Field

        private CarCatalog _carCatalog;
        private ObservableCollection<Car> _carCollection;
        private Facade _facade;

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

        public Command AddCar { set; get; }

        // Constructor

        public RegisterCarViewModel()
        {
            _carCatalog = new CarCatalog();

            AddCar = new Command(DoCommand);

            CarCollection = new ObservableCollection<Car>();

            _facade = new Facade();
            //_facade.Save(_carCollection);

            this.LoadData();
        }

        // Commands

        public void DoCommand(object newItem)
        {
            int cmdId = ID;
            string cmdName = Name;
            string cmdBrand = Brand;
            string cmdColor = Color;
            int cmdYear = Year;
            string cmdComment = Comment;

            Car car = _carCatalog.CreatNewCar(cmdId, cmdName, cmdBrand, cmdColor, cmdYear, cmdComment);

            CarCollection.Add(car);
            _facade.Save(_carCollection);
        }

        public async void LoadData()
        {
            try
            {
                ObservableCollection<Car> car = await _facade.Load();

                this._carCollection = car;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is: " + ex,"Error");
            }
            
        }
    }
}
