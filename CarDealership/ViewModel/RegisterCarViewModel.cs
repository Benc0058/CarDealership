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
using Windows.UI.Xaml.Navigation;


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
        public int Price { set; get; }
        public string searchforcar { set; get; }
        private Car _selectedCar;
        public Car SelectedCar
        {
            set
            {
                if (_selectedCar != value)
                    _selectedCar = value;

                OnPropertyChanged("_SelectedCar");
            }
        
            get { return _selectedCar; }
          
        }
        private int _selectedindex;
        public string imagepath { get; set; }
        public int SelectedID
        {
            set
            {
                if (_selectedindex != value)
                    _selectedindex = value;

            }
            get
            {
                return _selectedindex;
            }
        }
            
        // Commands
        public Command AddCar { set; get; }
        public Command DeleteCar { set; get; }
        public Command searchCar { set; get; }

        // Constructor

        public RegisterCarViewModel()
        {
            //  _carCatalog = new CarCatalog();
            imagepath = "C:\\Users\\Jacob\\Documents\\OpelAstra.jpg";
            AddCar = new Command(DoCommand);
            DeleteCar = new Command(Deletecar);
            searchCar = new Command(SearchCar);


            CarCollection = CarCatalog._carList;


            // Methods
        }
        public void SearchCar(object newItem)
        {
            CarCatalog.SearchCar(searchforcar);
        }
        public void Deletecar(object newItem)
        {
            CarCatalog.DeleteCarByID(SelectedID);
        }

        public void DoCommand(object newItem)
        {

            //int cmdId = ID;
            //string cmdName = Name;
            //string cmdBrand = Brand;
            //string cmdColor = Color;
            //int cmdYear = Year;
            //string cmdComment = Comment;
            //int cmdPrice = Price;
            if (Validate(Name, Brand, Color, Year, Price))
            {
                Car car = CarCatalog.CreatNewCar(Name, Brand, Color, Year, Comment, Price);
            }
            else
            {
                string k = "Missing data, the following lines need to be filled out \n Name \n Brand\n Color \n Year \n Price \n Additionaly, Price and Year must be numbers";


                MessageBox.Show(k, "Missing data");
            }


        }
        public bool Validate(string name, string brand, string color, int year, int price)
        {
            if (string.IsNullOrEmpty(name)) { return false; }
            if (string.IsNullOrEmpty(brand)) { return false; }
            if (string.IsNullOrEmpty(color)) { return false; }
            if (year == 0) { return false; }
            if (price == 0) { return false; }
            return true;
        }

    }
}

