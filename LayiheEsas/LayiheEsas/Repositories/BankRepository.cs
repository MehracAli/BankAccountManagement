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
            Console.WriteLine(user.Balance);
        }

        public void TopUpBalance(User user)
        {
            Console.WriteLine(user.Balance);
        }
        public string ChangePassword(User user)
        {
            return user.Password;
        }
        public void BankUserList(User user)
        {
            foreach (User userList in _bank.Users)
            {
                Console.WriteLine($"Name: {userList.Name}; Surname: {userList.Surname}");
            }
        }

        public void BlockUser(User user)
        {
            Console.WriteLine($"User: {user.Name} {user.Surname} is blocked!");
        }
        public void Logout(Bank bank)
        {
            
        }

    }
}
