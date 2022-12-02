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
        public void TopUpBalance(Bank bank);
        public void ChangePassword(Bank bank);
        public void BankUserList(Bank bank);
        public void BlockUser(Bank bank);

    }
}
