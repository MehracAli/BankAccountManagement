using LayiheEsas.Entities;
using LayiheEsas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Services
{
    internal class UserService
    {
        public IUserRepository userRepository;

        public UserService(Bank bank)
        {
            userRepository = new UserRepository(bank);
        }

        #region UserRegister
        public bool UserRegistration(string name, string surname, string email, string password, bool isAdmin)
        {
            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                Console.WriteLine(" ");
                Console.WriteLine("-->This email is already registered...");
                Thread.Sleep(3000);
                return false;
                }
            }
            User user = new User(name, surname, email, password, isAdmin);
            userRepository.UserRegistration(user);
            return true;
        }
        #endregion

        #region UserLogin
        public void UserLogin(string email, string password)
        {
            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email) && userList.Password.Equals(password))
                {
                    userRepository.UserLogin(userList);
                    MenuService.BankService();
                }
            }
            Console.WriteLine("--> You are not registered...");
            Thread.Sleep(3000);
        } 
        #endregion

        #region FindUser
        public void FindUser(string email)
        {
            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                    userRepository.FindUser(userList);
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Ending...");
            Thread.Sleep(1500);
        } 
        #endregion

    }
}
