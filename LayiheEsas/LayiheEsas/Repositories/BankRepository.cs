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

        public void BankUserList(Bank bank)
        {
            throw new NotImplementedException();
        }

        public void BlockUser(Bank bank)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(Bank bank)
        {
            throw new NotImplementedException();
        }

        public void CheckBalance(User user)
        {
            Console.WriteLine(user.Balance);
        }

        public void TopUpBalance(Bank bank)
        {
            throw new NotImplementedException();
        }
    }
}
