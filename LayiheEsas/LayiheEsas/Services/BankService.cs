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
        public IBankRepository _bankRepository;

        public BankService(Bank bank)
        {
            _bankRepository = new BankRepository(bank);
        }

        #region CheckBalance
        public bool CheckBalance(string password)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {
                if (userList.Password == password)
                {
                    _bankRepository.CheckBalance(userList);
                    return true;
                }
            }
            return true;
        }
        #endregion

        #region TopUpBalance
        public bool TopUpBalance(string password, double newBalance)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {
                if (userList.Password == password)
                {
                    userList.Balance += newBalance;
                    _bankRepository.TopUpBalance(userList);
                    return true;
                }
            }
            return true;
        }
        #endregion

        #region ChangePassword
        public bool ChangePassword(string email, string currentPassword, string newPassword)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {
                if (userList.Email == email && userList.Password == currentPassword)
                {
                    userList.Password = newPassword;
                    _bankRepository.ChangePassword(userList);
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong password");
                    Thread.Sleep(2000);
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region BankUserList
        public bool BankUserList(string email)
        {
            foreach(User userList in _bankRepository.bank.Users)
            {
                if(userList.Email == email)
                {
                    if(userList.IsAdmin == true)
                    {
                        _bankRepository.BankUserList(userList);
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region BlockUser
        public bool BlockUser(string email)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {
                if(userList.Email == email)
                {
                    userList.IsBlocked = true;
                    return true;                  
                }
            }
            return true;
        }
        #endregion

        #region Logout
        public void Logout()
        {
        } 
        #endregion
    }

}
