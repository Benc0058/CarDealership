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

        public CommandLogin LoginCommand
        {
            get; set;
        }

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
            User admin = new User("Bence", "TheStar");
            //User kisadmin = new User("Jakub", "Cool");

            // Add the User to the collection
            _users.Add(admin);
            //_users.Add(kisadmin);

        }

        // Methods
        public void CheckLogin()
        {
            if (_users != null)
            {
                foreach (var user in _users)
                {
                    if ((user.UserName == CurrentUser.UserName) && (user.Password == CurrentUser.Password))
                    {
                        //MessageBox.Show("You successfully logged into the CarDealership's system!", "Login Page");
                        Frame rootFrame = Window.Current.Content as Frame;
                        rootFrame = new Frame();
                        rootFrame.Navigate(typeof(RegisterCarPage)); // if u want to send the user data just ,CurrentUser
                        Window.Current.Content = rootFrame;
                        Window.Current.Activate();
                        break;
                    }
                    else if ((user.UserName != CurrentUser.UserName) || (user.Password != CurrentUser.Password))
                    {
                        MessageBox.Show("Username or Password is incorrect!", "Login Page");
                        OnPropertyChanged("rootFrame");                 
                        break;
                    }
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
