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
                if (userList.Password.Equals(password))
                {
                    _bankRepository.CheckBalance(userList);
                    return true;
                }
            }
            return true;
        }
        #endregion

        #region TopUpBalance
        public void TopUpBalance(string email, double newBalance)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                    userList.Balance += newBalance;
                    _bankRepository.TopUpBalance(userList);
                }
                else
                {
                    Console.WriteLine("--> Incorrect email...");
                    Thread.Sleep(3000);
                }
            }
        }
        #endregion

        #region ChangePassword
        public bool ChangePassword(string email, string currentPassword, string newPassword)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {
                if (userList.Email == email && userList.Password == currentPassword)
                {

                    if ((MenuService.CheckPassword(newPassword)))
                    {
                        userList.Password = newPassword;
                        _bankRepository.ChangePassword(userList);
                    }       
                    
                    return true;
                }

                Console.WriteLine("Wrong password");
                Thread.Sleep(2000);
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
        public void BlockUser(string userEmail)
        {
            foreach (User user in _bankRepository.bank.Users)
            {
                _bankRepository.BankUserList(user);
                break;
            }

            Console.WriteLine("Enter user email which you want block:");
            userEmail = Console.ReadLine();

            foreach (User userList in _bankRepository.bank.Users)
            {

                if (userList.Email.Equals(userEmail))
                {
                    userList.IsBlocked = true;
                    _bankRepository.BlockUser(userList);
                }
            }
        }
        #endregion

        #region Logout
        public void Logout()
        {
        } 
        #endregion
    }

}
