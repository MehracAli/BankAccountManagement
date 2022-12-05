using LayiheEsas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Repositories
{
    internal class UserRepository:IUserRepository
    {
        readonly Bank _bank;
        public Bank bank {get { return _bank;}}

        public UserRepository(Bank bank)
        {
            _bank = bank;         
        }

        #region UserRegistration
        public void UserRegistration(User user)
        {
            Array.Resize(ref bank.Users, bank.Users.Length + 1);
            bank.Users[bank.Users.Length - 1] = user;
            Console.WriteLine(" ");
            Console.WriteLine("You have successfully registered!");
            Thread.Sleep(1500);
        }

        #endregion

        #region UserLogin
        public void UserLogin(User user)
        {
            user.IsLogged = true;
            Console.WriteLine("You are successfully logged in!\n");
            Console.WriteLine($"User: {user.Name} {user.Surname}");
            Console.WriteLine($"IsAdmin status: {user.IsAdmin}");
            Console.WriteLine($"ID: {user.Id}");
        }
        #endregion

        #region FindUser
        public void FindUser(User user)
        {
            Console.WriteLine($"User fined: {user.Name} {user.Surname}");
            if(user.IsAdmin) 
            {
                Console.WriteLine("Admin");
            }
            Thread.Sleep(3000);
        } 
        #endregion
    }
}
