using LayiheEsas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Repositories
{
    internal interface IBankRepository
    {
        public Bank bank { get; }

        public void CheckBalance(User user);
        public void TopUpBalance(User user);
        public string ChangePassword(User user);
        public void BankUserList(User user);
        public void BlockUser(User user);

        public void Logout(Bank bank);

    }
}
