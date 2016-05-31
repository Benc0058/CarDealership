using System;
using System.Collections.ObjectModel;
using CarDealership.Catalog;
using CarDealership.Interfaces;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CarDealership.View;
using CarDealership.Model;
using Windows.UI.Xaml.Navigation;
using CarDealership.Persistency;


namespace CarDealership.ViewModel
{
    public class RegisterCarViewModel : Notification
    {
        // Instance Field
        private ObservableCollection<Car> _carCollection;
        private Facade _facade;             //for save and load the data to file
        private Car _selectedCar;           //

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

        //Properties related to adding a car

        public int ID { set; get; }
        public string Name { set; get; }
        public string Brand { set; get; }
        public string Color { set; get; }
        public string Year { set; get; }
        public string Comment { set; get; }
        public string Price { set; get; }
        public string ImagePath { set; get; }

        // Property relaed to search for car

        public string searchforcar { set; get; }

        public Car SelectedCar
        {
            set
            {
                _selectedCar = value;
                OnPropertyChanged("_SelectedCar");
            }

            get { return _selectedCar; }

        }
        // Commands 
        public Command AddCar { set; get; }
        public Command DeleteCar { set; get; }
        public Command searchCar { set; get; }
        public Command CreateInvoiceWithSelectedCar { set; get; }

        // Constructor

        public RegisterCarViewModel()
        {

            AddCar = new Command(addCar);
            DeleteCar = new Command(Deletecar);
            searchCar = new Command(SearchCar);
            CreateInvoiceWithSelectedCar = new Command(CreateInvoice);

            CarCollection = CarCatalog._carList;

            _facade = new Facade();
            this.LoadData();
        }

        // Command functions

        public void CreateInvoice(object newItem)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame = new Frame();
            rootFrame.Navigate(typeof(InvoiceView), SelectedCar); // if u want to send the user data just ,CurrentUser
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        public void SearchCar(object newItem)
        {
            CarCatalog.SearchCar(searchforcar);
        }

        public void Deletecar(object newItem)
        {
            if (SelectedCar != null)
            {
                CarCatalog._carList.Remove(SelectedCar);
                _facade.Save();
            }
        }

        public void addCar(object newItem)
        {
            if (Validate(Name, Brand, Color, Year, Price) == "true")
            {
                Car car = CarCatalog.CreatNewCar(Name, Brand, Color, Year, Comment, Price + " Dkk", "ms-appx:///CarPictures/" + ImagePath);
                _facade.Save();
            }
            else
            {
                MessageBox.Show(Validate(Name, Brand, Color, Year, Price), "Missing data");
            }
        }

        public string Validate(string name, string brand, string color, string year, string price)
        {
            if (string.IsNullOrEmpty(name)) { return "Name is empty"; }
            if (string.IsNullOrEmpty(brand)) { return "Brand is empty"; }
            if (string.IsNullOrEmpty(color)) { return "Color is empty"; }
            if (string.IsNullOrEmpty(Year)) { return "Year is empty"; }
            if (string.IsNullOrEmpty(Price)) { return "Price is empty"; }
            try
            {
                int x = Int32.Parse(Year);
                if ((x < 1900) || (x > 2016))
                {
                    return "Invalid Year";
                }
            }
            catch
            {
                return "Year Must Be a Number";
            }
            try
            {
                int x = Int32.Parse(Price);
                if (x < 1)
                {
                    return "Invalid Year";
                }
            }
            catch
            {
                return "Price Must Be a Number";
            }
            return "true";
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
                MessageBox.Show("Error is: " + ex, "Error");
            }
        }
    }
}
