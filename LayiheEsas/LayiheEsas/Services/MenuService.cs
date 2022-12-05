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
        static Bank bank;

        static MenuService()
        {
            bank = new Bank();
            bankService = new BankService(bank);
            userService = new UserService(bank);
        }

        #region UserRegistration
        public static void UserRegistration()
        {
            string name;
            string surname;
            string email;
            string password;
            bool isAdmin;

            do
            {
                Console.WriteLine("Please enter name:");
                name = Console.ReadLine();
            } while (!CheckNameSurname(name));

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
            } while (!CheckEmail(email));

            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please enter password:");
                password = Console.ReadLine();
            } while (!CheckPassword(password));

            string Admin = null;
            char yesNo;
        start:
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Are you admin?: y(yes) or n(no)");
                isAdmin = char.TryParse(Console.ReadLine(), out yesNo);
            } while (!isAdmin);

            if (yesNo.ToString().ToLower() == 'y'.ToString())
            {
                userService.UserRegistration(name, surname, email, password, true);
            }
            else if (yesNo.ToString().ToLower().Equals('n'.ToString()))
            {
                userService.UserRegistration(name, surname, email, password, false);
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("--> You can enter only 'y' or 'n'...");
                goto start;
            }

        }
        #endregion

        #region UserLogin
        public static void UserLogin()
        {
            string email;
            string password;
            Console.WriteLine("Login here: \n");
            Console.WriteLine("Enter email:");
            email = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Enter password:");
            password = Console.ReadLine();

            if (IsBlockedOrNo(email).Equals(false))
            {
                userService.UserLogin(email, password);
            }
                Console.WriteLine("You are blocekd!");
                Thread.Sleep(1000);
        }
        #endregion

        #region FindUser
        public static void FindUser()
        {
            string email;
            Console.WriteLine("Enter email for find user:");
            email = Console.ReadLine();
            userService.FindUser(email);
        }
        #endregion

        #region CheckBalance
        public static void CheckBalance()
        {
            string email;
            Console.WriteLine("Enter password: ");
            email = Console.ReadLine();
            bankService.CheckBalance(email);
        }
        #endregion

        #region TopUpBalance
        public static void TopUpBalance()
        {
            string email;
            double newBalance;
            
            Console.WriteLine("Enter email:");
            email = Console.ReadLine();
            Console.WriteLine("Enter balance:");
            bool result = double.TryParse(Console.ReadLine(), out newBalance);
           
            if (result)
            {
                bankService.TopUpBalance(email, newBalance);
                Console.WriteLine("Loading...");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("--> Contain cant be a letter...");
                Thread.Sleep(1500);
            }
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
                Console.WriteLine("Please enter your email:");
                email = Console.ReadLine();
                Console.WriteLine("Please enter current password:");
                currentPassword = Console.ReadLine();
                Console.WriteLine("Please enter new password");
                newPassword = Console.ReadLine();
            } while (!bankService.ChangePassword(email, currentPassword, newPassword));
        }
        #endregion

        #region BankUserList
        public static void BankUserList()
        {
            string email;

            Console.WriteLine("Enter email for show userlist");
            email = Console.ReadLine();

            bankService.BankUserList(email);
        }
        #endregion

        #region BlockUser
        public static void BlockUser()
        {

            string adminEmail;
            string userEmail = string.Empty;
            string password;
            Console.WriteLine("Enter admin email and password:\n");
            Console.Write("Email: ");
            adminEmail = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();
            if (IsAdminOrNo(adminEmail,password).Equals(true))
            {
                bankService.BlockUser(userEmail);
            }
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
            Console.WriteLine("--> Name or surname must be at least 3 characters long.\n");
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

            if (password.Length < 8)
            {
                Console.WriteLine("--> Passüord must be at least 8 characters long.\n");
                Thread.Sleep(1500);
                return false;
            }

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

            Console.WriteLine("--> password must contain at least 1 lowercase letter, 1 uppercase letter and at least 1 number.\n");
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
            Console.WriteLine("--> The email must contain the @ symbol.\n");
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

        #region IsAdminOrNo
        public static bool IsAdminOrNo(string email, string password)
        {
            foreach (User userList in bankService._bankRepository.bank.Users)
            {
                if (userList.Email.Equals(email) || userList.Password.Equals(password))
                {
                    return true;
                }

                Console.WriteLine("You aren't admin...");
                Thread.Sleep(1500);
            }
            return false;
        }
        #endregion

        #region IsBlockedOrNo
        public static bool IsBlockedOrNo(string email)
        {
            foreach (User userList in bankService._bankRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                    if (userList.IsBlocked)
                    {
                        return true;
                    }
                }
            }
            return false;
        } 
        #endregion
    }
}
