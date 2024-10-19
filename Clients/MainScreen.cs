using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_System.Transactions;

namespace Bank_System.Clients
{
    internal class MainScreen
    {
        private enum enMainMenueOptions
        {
            eListClients = 1, eAddNewClient = 2, eDeleteClient = 3,
            eUpdateClient = 4, eFindClient = 5, eShowTransactionsMenue = 6,
            eManageUsers = 7, eLoginRegister = 8, eCurrncyExchange = 9, eExit = 10
        };


        private static short _ReadMainMenueOption()
        {
            Console.WriteLine("Choose what do you want to do? [1 to 10]? ");
            short inputUser;
            bool isValidInput = false;
            do
            {
                Console.WriteLine("Enter Number between 1 to 10? ");
                isValidInput = short.TryParse(Console.ReadLine(), out inputUser);
            } while (!(inputUser >= 1 && inputUser <= 10) || !isValidInput);
            return inputUser;
        }

        private static void _PerfromMainMenueOption(enMainMenueOptions options)
        {
            switch (options)
            {
                case enMainMenueOptions.eAddNewClient:
                    Console.Clear();
                    Clients.AddNewClient();
                    break;
                case enMainMenueOptions.eListClients:
                    Console.Clear();
                    Clients.ShowAllClients();
                    break;
                case enMainMenueOptions.eFindClient:
                    Console.Clear();
                    Clients.FindClient();
                    break;
                case enMainMenueOptions.eUpdateClient:
                    Console.Clear();
                    Clients.UpdataClient();
                    break;
                case enMainMenueOptions.eDeleteClient:
                    Console.Clear();
                    Clients.DeleteClient();
                    break;
                case enMainMenueOptions.eShowTransactionsMenue:
                    Console.Clear();
                    TransactionsScreen.ShowTransactionsMainMenue();
                    break;
                case enMainMenueOptions.eExit:
                    Console.Clear();
                    break;
            }
        }

        public static void ShowMainMenue()
        {
            Console.Clear();

            Console.WriteLine("===========================================");
            Console.WriteLine("\t\t\tMain Menu");
            Console.WriteLine("===========================================");
            Console.WriteLine("\t[1] Show Client List.");
            Console.WriteLine("\t[2] Add New Client.");
            Console.WriteLine("\t[3] Delete Client.");
            Console.WriteLine("\t[4] Update Client.");
            Console.WriteLine("\t[5] Find Client.");
            Console.WriteLine("\t[6] Transactions.");
            Console.WriteLine("\t[7] Manage Users.");
            Console.WriteLine("\t[8] Login Register.");
            Console.WriteLine("\t[9] Currency Exchange.");
            Console.WriteLine("\t[10] Logout.");
            Console.WriteLine("===========================================");
            _PerfromMainMenueOption((enMainMenueOptions)_ReadMainMenueOption());
        }

    }
}
