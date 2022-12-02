using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Entities
{
    internal class User
    {
        public string Name, Surname, Email, Password;
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
