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


        #region UserRegistration
        public static void UserRegistration()
        {
            string name;
            string surname;
            string email;
            string password;
            bool isAdmin = false;

            do
            {
                Console.WriteLine("Please enter name:");
                name = Console.ReadLine();
                
            } while (!CheckNameSurname(name) == true);

            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please enter surname:");
                surname = Console.ReadLine();
            } while (!CheckNameSurname(surname));
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please enter email:");
                email = Console.ReadLine();
            } while (!CheckEmail(email) == true);

            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please enter password:");
                password = Console.ReadLine();
            } while (!CheckPassword(password) == true);

            string Admin = null;
            Console.WriteLine(" ");
            Console.WriteLine("Are you super admin yes/no:");
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
        public static bool UserLogin()
        {
            string email;
            string password;
            do
            {
                Console.WriteLine("Login here: \n");
                Console.WriteLine("Enter Email:");
                email = Console.ReadLine();
                Console.WriteLine(" ");
                Console.WriteLine("Enter Password:");
                password = Console.ReadLine();
            } while (!userService.UserLogin(email, password));

            return true;
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

            } while (userService.FindUser(email));
        }
        #endregion

        



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

        #region Logout
        public static void Logout()
        {
            MenuService.UserService();
        } 
        #endregion

        #region CheckMethods

        #region CheckNameSurname
        public static bool CheckNameSurname(string nameOrSurname)
        {
            if (nameOrSurname.Length > 3)
            {
                return true;
            }
            Console.WriteLine("--> Name or surname must contain minimum 3 characters:");
            Thread.Sleep(1500);
            Console.Clear();
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
            Console.WriteLine("--> Enter valid password");
            Thread.Sleep(1500);
            Console.Clear();
            return false;
        } 
        #endregion

        #region CheckEmail
        public static bool CheckEmail(string email)
        {
            if (email.Contains('@'))
            {
                return true;
            }
            Console.WriteLine("--> Email must contain '@' symbol");
            Thread.Sleep(1500);
            Console.Clear();
            return false;
        }
        #endregion

        #endregion

        #region BankService

        public static void BankService()
        {
            char BankServiceSelection;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your IBank service\n");
            do
            {
                Console.WriteLine("1. Check balance");
                Console.WriteLine("2. Top up balance");
                Console.WriteLine("3. Change password");
                Console.WriteLine("4. Bank user list");
                Console.WriteLine("5. Block user");
                Console.WriteLine("6. Logout");
            selection1:
                BankServiceSelection = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine();
                switch (BankServiceSelection)
                {
                    case '1':
                        MenuService.CheckBalance();
                        Console.Clear();
                        break;
                    case '2':
                        MenuService.TopUpBalance();
                        Console.Clear();
                        break;
                    case '3':
                        MenuService.ChangePassword();
                        Console.Clear();
                        break;
                    case '4':
                        MenuService.BankUserList();
                        Console.Clear();
                        break;
                    case '5':
                        MenuService.BlockUser();
                        Console.Clear();
                        break;
                    case '6':
                        MenuService.Logout();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please choose correct number");
                        Console.Clear();
                        goto selection1;
                }
            } while (BankServiceSelection != '0');
        }
        #endregion

        #region UserService
        public static void UserService()
        {

            char UserServiceSelection;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Ibank\n");
            do
            {
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Find User");
                Console.WriteLine("0. Exit");
            selection:
                UserServiceSelection = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine();
                switch (UserServiceSelection)
                {
                    case '1':
                        MenuService.UserRegistration();
                        Console.Clear();
                        break;
                    case '2':
                        MenuService.UserLogin();
                        Console.Clear();
                        break;
                    case '3':
                        MenuService.FindUser();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please choose correct number");
                        Console.Clear();
                        goto selection;
                }
            } while (UserServiceSelection != '0');
        }
        #endregion
    }
}
