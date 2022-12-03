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

        public UserService()
        {
            userRepository = new UserRepository();
        }

        #region UserRegister
        public User UserRegistration(string name, string surname, string email, string password, bool isAdmin)
        {
        start:
            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                    Console.WriteLine("This email was registered.");
                    goto start;
                }
            }
            User user = new User(name, surname, email, password, isAdmin);
            userRepository.UserRegistration(user);
            return user;
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
                    return true;
                }
            }

            return false;
        } 
        #endregion

        #region FindUser
        public bool FindUser(string email)
        {
            User user = null;

            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                    user = userList;
                    return true;
                }
            }
            userRepository.FindUser(user);
            return false;
        } 
        #endregion

    }
}
