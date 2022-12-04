using LayiheEsas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Repositories
{
    internal class BankRepository : IBankRepository
    {
        Bank _bank;
        public Bank bank { get { return _bank; } }

        public BankRepository()
        {
            _bank = new Bank();
        }

        public void CheckBalance(User user)
        {
            Console.WriteLine("Your current balance:");
            Console.WriteLine(user.Balance);
            Thread.Sleep(2000);
        }

        public void TopUpBalance(User user)
        {
            Console.WriteLine("Your current balance:");
            Console.WriteLine(user.Balance);
            Thread.Sleep(2000);
        }
        public void ChangePassword(User user)
        {
            Console.WriteLine("Password succesfully changed");
            Thread.Sleep(2000);
        }
        public void BankUserList(User user)
        {
            foreach (User userList in _bank.Users)
            {
                Console.WriteLine($"Name: {userList.Name}; Surname: {userList.Surname}");
                Thread.Sleep(2000);
            }
        }

        public void BlockUser(User user)
        {
            Console.WriteLine($"User: {user.Name} {user.Surname} is blocked!");
            Thread.Sleep(2000);
        }
        public void Logout(Bank bank)
        {
        }

    }
}
