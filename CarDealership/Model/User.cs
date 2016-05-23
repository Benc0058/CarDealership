﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class User
    {
        // Instance Field

        private string _userName;
        private string _password;

        //Properties

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        // Constructor

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public User()
        {
            
        }
    }
}
