using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_System.Clients;

namespace Bank_System.Transactions
{
    internal class TransactionsScreen
    {
        private enum enTransactionsMenueOptions
        {
            eDeposit = 1, eWithdraw = 2, eShowTotalBalance = 3, eTransfer = 4, eTransferLog = 5, eShowMainMenue = 6
        };
        private static short _ReadMainMenueOption()
        {
            Console.WriteLine("Choose what do you want to do? [1 to 6]? ");
            short inputUser;
            bool isValidInput = false;
            do
            {
                Console.WriteLine("Enter Number between 1 to 6? ");
                isValidInput = short.TryParse(Console.ReadLine(), out inputUser);
            } while (!(inputUser >= 1 && inputUser <= 6) || !isValidInput);
            return inputUser;
        }

        private static void _PerformTransactionsMenueOption(enTransactionsMenueOptions options)
        {
            switch (options)
            {
                case enTransactionsMenueOptions.eDeposit:
                    Console.Clear();
                    Transactions.ShowDeposit();
                    break;
                case enTransactionsMenueOptions.eWithdraw:
                    Console.Clear();
                    Transactions.ShowWithdraw();
                    break;
                case enTransactionsMenueOptions.eShowTotalBalance:
                    Console.Clear();
                    Transactions.ShowTotalBalance();
                    break;
                case enTransactionsMenueOptions.eTransfer:
                    Console.Clear(); 
                    Transactions.ShowTransfer();
                    break;
                case enTransactionsMenueOptions.eTransferLog:
                    Console.Clear();
                    break;
                case enTransactionsMenueOptions.eShowMainMenue:
                    Console.Clear();
                    MainScreen.ShowMainMenue();
                    break;
            }
        }

        public static void ShowTransactionsMainMenue()
        {
            Console.Clear();

            Console.WriteLine("===========================================");
            Console.WriteLine("\tTransactions Menue");
            Console.WriteLine("===========================================");
            Console.WriteLine("\t[1] Deposit");
            Console.WriteLine("\t[2] Withdraw");
            Console.WriteLine("\t[3] Show Total Balance");
            Console.WriteLine("\t[4] Transfer");
            Console.WriteLine("\t[5] Transfer Log");
            Console.WriteLine("\t[6] Show Main Menue");
            Console.WriteLine("===========================================");
            _PerformTransactionsMenueOption((enTransactionsMenueOptions)_ReadMainMenueOption());
        }

    }
}
