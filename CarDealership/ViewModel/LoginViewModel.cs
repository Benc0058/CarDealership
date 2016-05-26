using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CarDealership.Interfaces;
using CarDealership.Model;
using CarDealership.Persistency;
using CarDealership.View;

namespace CarDealership.ViewModel
{
    public class LoginViewModel : Notification
    {
        // Interface Field

        private User _currentUser;
        //private UserFacade _facade;
        private ObservableCollection<User> _users;

        public event EventHandler LoginCompleted;

        // Properties

        public User CurrentUser
        {
            set
            {
                if (CurrentUser != value)
                {
                    _currentUser = value;
                    OnPropertyChanged("CurrentUser");
                }
            }
            get { return _currentUser; }
        }

        public CommandLogin LoginCommand { get; set; }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        // Constructor 

        public LoginViewModel()
        {
            CurrentUser = new User();
            LoginCommand = new CommandLogin(DoLogin);
            //_facade = new UserFacade();
            _users = new ObservableCollection<User>();

            // Add a new User
            User bence = new User("Bence", "TheStar");
            User jakub = new User("Jakub", "Cool");
            User mohamed = new User("Mohamed", "TheTeacer");
            User zuhair = new User("Zuhair", "mod");

            // Add the User to the collection
            _users.Add(bence);
            _users.Add(jakub);
            _users.Add(mohamed);
            _users.Add(zuhair);
        }

        // Methods
        public void CheckLogin()
        {
            bool LoginStatus = false;
            if (_users != null)
            {
                foreach (var user in _users)
                {
                    if ((user.UserName == CurrentUser.UserName) && (user.Password == CurrentUser.Password))
                    {
                        LoginStatus = true;
                        MessageBox.Show("Logged into the Car Dealership's system!", CurrentUser.UserName);
                        Frame rootFrame = Window.Current.Content as Frame;
                        rootFrame = new Frame();
                        rootFrame.Navigate(typeof (RegisterCarPage)); // if u want to send the user data just ,CurrentUser
                        Window.Current.Content = rootFrame;
                        Window.Current.Activate();
                        break;
                    }
                }
                if (LoginStatus == false)
                {
                    MessageBox.Show("Username or Password is incorrect!", "Excuse us" + CurrentUser.UserName);
                }
            }
        }
    




// Commands

        public async void DoLogin(object obj)
        {
            CheckLogin();
        }
    }
}
