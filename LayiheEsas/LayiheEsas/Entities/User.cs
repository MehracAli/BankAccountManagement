using LayiheEsas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Entities
{
    internal class User
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (MenuService.CheckNameSurname(value))
                {
                    _name = value;
                }
            }
        }
        string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (MenuService.CheckNameSurname(value))
                {
                    _surname = value;
                }
            }
        }
        string _email;
        public string Email 
        {
            get { return _email; }
            set
            {
                if (value.Contains('@'))
                {
                    _email = value;
                }   
            }
        }
        string _password;
        public string Password
        { 
            get { return _password; }
            set
            {
                bool hasDigit = false;
                bool hasLower = false;
                bool hasUpper = false;
                bool result = false;

                foreach (char characters in value)
                {


                    if (char.IsDigit(characters))
                    {
                        hasDigit = true;
                    }
                    else if (char.IsLower(characters))
                    {
                        hasLower = true;
                    }
                    else if (char.IsUpper(characters))
                    {
                        hasUpper = true;
                    }

                    result = hasDigit && hasLower && hasUpper;
                    if (result)
                    {
                        _password = value;
                    }
                }
            }
        }
        public int Id;
        public double Balance;
        public bool IsAdmin, IsBlocked, IsLogged;
        static int count;
        public User(string name, string surname, string email, string password, bool isAdmin)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;

            Id = ++count;
            Balance = default;
            
            IsAdmin = false;
            IsBlocked = false;
            IsLogged = false;
        }

    }
}
