using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LifelineWinForm
{
    class Person
    {
        // Instance
        private int _userID;
        private string _username;
        private string _password;
        private bool _isAdmin;

        // Property
        public int UserID
        {
            get { return _userID; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        //Method
        public Boolean Login(string Username, string Password, bool IsAdmin)
        {
            if (IsAdmin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Logout(string Username)
        {
            return true;
        }

        public void CreateAccount()
        {

        }

        public void editAccount()
        {

        }
    }

    class User : Person 
    {
        //Instance
        private int _email;

        //Property
        public int Email
        {
            get { return _email; }
            set { _email = value; }
        }

        //Method
        public void ViewActivity()
        {

        }

        public void AddActivity()
        {

        }

        public void EditActivity()
        {

        }

        public void DeleteActivity()
        {

        }
    }

    class Admin : Person
    {
        //Method
        public void AddAccount()
        {

        }

        public void DeleteAccount(string Username)
        {

        }
    }
}
