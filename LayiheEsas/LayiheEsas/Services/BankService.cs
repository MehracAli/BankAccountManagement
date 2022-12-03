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
            return false;
        }
        #endregion

        #region TopUpBalance
        public bool TopUpBalance(string password, double newBalance)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {
                if (userList.Password == password)
                {
                    userList.Balance = newBalance;
                    _bankRepository.TopUpBalance(userList);
                    return true;
                }
            }
            return false;
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
