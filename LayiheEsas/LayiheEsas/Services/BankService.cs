using LayiheEsas.Entities;
using LayiheEsas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Services
{
    internal class BankService
    {
        readonly IBankRepository _bankRepository;

        public BankService()
        {
            _bankRepository = new BankRepository();
        }

        public bool CheckBalance(int id)
        {
            foreach(User userList in _bankRepository.bank.Users) 
            { 
                if (userList.Id == id)
                {
                    _bankRepository.CheckBalance(userList);
                    return true;
                }
            }
            return false;
        }

        public void TopUpBalance(User user, double newBalance)
        {
            
        }

    }

}
