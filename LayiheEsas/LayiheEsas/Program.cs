using LayiheEsas.Entities;
using LayiheEsas.Services;

namespace LayiheEsas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char selection;
            Console.WriteLine("Welcome to Ibank");
            do
            {
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Find user");
            selection:
                selection = Convert.ToChar(Console.ReadLine());
                Console.WriteLine();
                switch (selection)
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
            } while (selection != '0');

        }
    }
}