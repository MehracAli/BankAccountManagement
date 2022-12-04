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
                if (userList.Email == email)
                {
                Console.WriteLine(" ");
                Console.WriteLine("-->This email was register!");
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
        public bool UserLogin(string email, string password)
        {

            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email) && userList.Password.Equals(password))
                {
                    userRepository.UserLogin(userList);
                    MenuService.BankService();
                    return true;
                }
            }
            Console.WriteLine("You didn't registered!");
            Thread.Sleep(3000);
            return false;
        } 
        #endregion

        #region FindUser
        public bool FindUser(string email)
        {

            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                    userRepository.FindUser(userList);
                    return true;
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("User not found...");
            Thread.Sleep(3000);
            return false;
        } 
        #endregion

    }
}
