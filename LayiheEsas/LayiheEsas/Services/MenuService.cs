using LayiheEsas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayiheEsas.Services
{
    internal static class MenuService
    {
        readonly static BankService bankService;
        readonly static UserService userService;

        static MenuService()
        {
            bankService = new BankService();
            userService = new UserService();
        }

        #region UserServiceMethods

        #region UserRegistration
        public static void UserRegistration()
        {
            string name;
            string surname;
            string email;
            string password;
            bool isAdmin = false;
            string Admin = null;

            do
            {
                Console.WriteLine("Please enter name: ");
                name = Console.ReadLine();
                
            } while (!CheckNameSurname(name) == true);

            do
            {
                Console.WriteLine("Please enter surname");
                surname = Console.ReadLine();
            } while (!CheckNameSurname(surname));
            do
            {
                Console.WriteLine("Please enter email");
                email = Console.ReadLine();
            } while (!CheckEmail(email) == true);

            do
            {
                Console.WriteLine("Please enter password");
                password = Console.ReadLine();
            } while (!CheckPassword(password) == true);

            Console.WriteLine("Are you super admin Yes/No");
            Admin = Console.ReadLine();

            if (Admin == "yes")
            {
                isAdmin = true;
            }
            else if (Admin == "no")
            {
                isAdmin = false;
            }

            userService.UserRegistration(name, surname, email, password, isAdmin);
        }
        #endregion

        #region UserLogin
        public static void UserLogin()
        {
            string email;
            string password;
            do
            {
                Console.WriteLine("Login here: ");
                Console.WriteLine("Enter Email");
                email = Console.ReadLine();
                Console.WriteLine("Enter Password");
                password = Console.ReadLine();
            } while (!userService.UserLogin(email, password));
        }
        #endregion

        #region FindUser
        public static void FindUser()
        {
            string email;
            do
            {
                Console.WriteLine("Enter email for find user:");
                email = Console.ReadLine();

            } while (!userService.FindUser(email));
        }
        #endregion

        #endregion

        #region BankServiceMethods

        #region CheckBalance
        public static void CheckBalance()
        {
            string password;
            do
            {
                Console.WriteLine("Enter password: ");
                password = Console.ReadLine();
            } while (!bankService.CheckBalance(password));
        }
        #endregion

        #region TopUpBalance
        public static void TopUpBalance()
        {
            string password;
            double newBalance;
            do
            {
                Console.WriteLine("Enter password: ");
                password = Console.ReadLine();
                Console.WriteLine("Enter balance: ");
                newBalance = Convert.ToInt32(Console.ReadLine());
            } while (!bankService.TopUpBalance(password, newBalance));
        }
        #endregion

        #region ChangePassword
        public static void ChangePassword()
        {
            string email;
            string currentPassword;
            string newPassword;
            do
            {
                email = Console.ReadLine();
                currentPassword = Console.ReadLine();
                newPassword = Console.ReadLine();
            } while (bankService.ChangePassword(email, currentPassword, newPassword));
        }
        #endregion

        #region BankUserList
        public static void BankUserList()
        {
            string email;
            do
            {
                Console.WriteLine("Enter email for show userlist");
                email = Console.ReadLine();
            } while (!bankService.BankUserList(email));
        }
        #endregion

        #region BlockUser
        public static void BlockUser()
        {
            BankUserList();

            string email;
            do
            {
                Console.WriteLine("Choose a user email which you want to block");
                email = Console.ReadLine();
            } while (!bankService.BlockUser(email));
        } 
        #endregion

        #endregion


        #region CheckMethods

        #region CheckNameSurname
        public static bool CheckNameSurname(string nameOrSurname)
        {
            if (nameOrSurname.Length > 3)
            {
                return true;
            }
            Console.WriteLine("Name or surname must contain minimum 3 characters:");
            return false;
        }
        #endregion


        #region CheckPassword
        public static bool CheckPassword(string password)
        {
            bool hasDigit = false;
            bool hasLower = false;
            bool hasUpper = false;
            bool result = false;

            foreach (char characters in password)
            {


                if (char.IsDigit(characters))
                {
                    hasDigit = true;
                }
                else if (char.IsLower(characters))
                {
                    hasLower = true;
                }
                else if (char.IsUpper(characters))
                {
                    hasUpper = true;
                }

                result = hasDigit && hasLower && hasUpper;
                if (result)
                {
                    return true;
                }
            }
            Console.WriteLine("Enter valid password");
            return result;
        }
        #endregion

        #region CheckEmail
        public static bool CheckEmail(string email)
        {
            if (email.Contains('@'))
            {
                return true;
            }
            Console.WriteLine("Email must contain @ symbol");
            return false;
        }
        #endregion

        #endregion
    }
}
