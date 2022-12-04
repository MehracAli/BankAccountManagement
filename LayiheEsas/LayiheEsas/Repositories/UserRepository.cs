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

        public UserRepository()
        {
            _bank = new Bank();         
        }

        #region UserRegistration
        public void UserRegistration(User user)
        {
            Array.Resize(ref bank.Users, bank.Users.Length + 1);
            bank.Users[bank.Users.Length - 1] = user;
            Console.WriteLine(" ");
            Console.WriteLine("You are registered!");
            Thread.Sleep(3000);
        }

        #endregion

        #region UserLogin
        public void UserLogin(User user)
        {
            user.IsLogged = true;
            Console.WriteLine("Is logged!");
            Console.WriteLine(" ");
            Console.WriteLine($"User: {user.Name} {user.Surname} is logged!");
            Thread.Sleep(3000);
        }
        #endregion

        #region FindUser
        public void FindUser(User user)
        {
            Console.WriteLine($"User fined: {user.Name} {user.Surname}");
            Thread.Sleep(3000);
        } 
        #endregion
    }
}
