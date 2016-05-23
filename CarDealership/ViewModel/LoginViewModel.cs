using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Interfaces;
using CarDealership.Model;
using CarDealership.Persistency;

namespace CarDealership.ViewModel
{
    public class LoginViewModel : Notification
    {
        // Interface Field

        private User _currentUser;
        //private UserFacade _facade;
        private ObservableCollection<User> _users;


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

        }

        // Methods

        public async void DoLogin(object obj)
        {
            // Add a new User
            User admin = new User("Bence", "TheStar");
            User kisadmin = new User("Jakub", "Cool");

            // Add the User to the collection
            _users.Add(admin);
            _users.Add(kisadmin);

            if (_users != null)
            {
                foreach (var user in _users)
                {
                    if ((user.UserName == CurrentUser.UserName) && (user.Password == CurrentUser.Password))
                    {
                        MessageBox.Show("You successfully logged into the CarDealership's system!", "Login Page"); // What should happen when u logged in
                    }
                    //else if ((user.UserName != CurrentUser.UserName) || (user.Password != CurrentUser.Password))
                    //{
                    //    MessageBox.Show("Username or Password is incorrect!", "Login Page");
                    //}
                }
            }
        }

        //public async Task<ObservableCollection<User>> LoadDafaultData()
        //public async void LoadData()
        //{
        //    try
        //    {
        //        _users = await _facade.Load();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error is: " + ex, "Error");
        //    }
        //}
    }
}
