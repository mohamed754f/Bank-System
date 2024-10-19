using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Transactions
{
    internal class Transactions
    {
        private static string ReadAccountNumber()
        {
            string accountNumber;
            Console.Write("\nPlease Enter Account Number to Transfer From: ");
            accountNumber = Bank.ReadString();  

            while (!Bank.IsClientExit(accountNumber))  
            {
                Console.Write("\nAccount number is not found, choose another one: ");
                accountNumber = Bank.ReadString();
            }

            return accountNumber;
        }
        public static void ShowDeposit()
        {
            Console.WriteLine("Deposit Screen");
            Console.WriteLine("Enter Account Number you want to Deposit");
            string AccountNumber = Bank.ReadString();

            while (!Bank.IsClientExit(AccountNumber))
            {
                Console.Write("Account Number is Not Used, Choose another one: ");
                AccountNumber = Bank.ReadString();
            }

            Bank Client1 = Bank.Find(AccountNumber);
            Bank._PrintClinet(Client1);

            double Amount = 0;
            Console.WriteLine("Enter Deposit Amount");
            Amount = Bank.ReadDouble();

            Console.WriteLine("Are you sure you want to perform this transaction? ");
            char Answer = 'n';
            Answer = char.Parse(Console.ReadLine());

            if (Answer == 'Y' || Answer == 'y')
            {
                Client1.Deposit(Amount, AccountNumber);
                Console.WriteLine("Amount Deposited Successfully.");
            }
            else
            {
                Console.WriteLine("Operation was cancelled.");
            }
        }

        public static void ShowWithdraw()
        {
            Console.WriteLine("Withdraw Screen");
            Console.WriteLine("Enter Account Number you want to Withdraw");
            string AccountNumber = Bank.ReadString();

            while (!Bank.IsClientExit(AccountNumber))
            {
                Console.Write("Account Number is Not Used, Choose another one: ");
                AccountNumber = Bank.ReadString();
            }

            Bank Client1 = Bank.Find(AccountNumber);
            Bank._PrintClinet(Client1);

            double Amount = 0;
            Console.WriteLine("Enter Withdraw Amount");
            Amount = Bank.ReadDouble();

            Console.WriteLine("Are you sure you want to perform this transaction? ");
            char Answer = 'n';
            Answer = char.Parse(Console.ReadLine());

            if (Answer == 'Y' || Answer == 'y')
            {
                Client1.Withdraw(Amount, AccountNumber);
                Console.WriteLine("Amount Withdrawed Successfully.");
            }
            else
            {
                Console.WriteLine("Operation was cancelled.");
            }
        }

        private static void PrintClientRecordLine(Bank client)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-10}",   // Change {4,-10} to {2,-10}
                            client._AccountNumber,
                            client.GetFullName(),
                            client._AccountBalance);
        }

        public static void ShowTotalBalance()
        {
            List<Bank> Clients = Bank._LoadClientsDataFromFile();

            Console.WriteLine($"==================== List Of {Clients.Count} Clients ====================\n\n");

            // Fix the placeholders in the header
            Console.WriteLine("{0,-15} | {1,-20} | {2,-10}",    // Change {4,-10} to {2,-10}
                "Account Number", "Client Name", "Balance");

            Console.WriteLine("______________________________________________________________");
            Console.WriteLine("______________________________________________________________\n");

            if (Clients.Count == 0)
            {
                Console.WriteLine("\t\t\t\tNo Clients Available In the System!");
            }
            else
            {
                foreach (Bank client in Clients)
                {
                    PrintClientRecordLine(client);
                }
            }

            Console.WriteLine("______________________________________________________________");
            Console.WriteLine("______________________________________________________________");
        }


        public static void ShowTransfer()
        {
            Console.WriteLine("Transfer Screen");

            Bank SourceClient = Bank.Find(ReadAccountNumber());
            Console.WriteLine("Source Client");
            Bank._PrintClinet(SourceClient);

            Bank DestinationClient = Bank.Find(ReadAccountNumber());
            Console.WriteLine("Destination Client");
            Bank._PrintClinet(DestinationClient);

            Console.WriteLine("Enter Amount");
            double Amount = Bank.ReadDouble();


            Console.WriteLine("Are you sure you want to perform this operation? y/n? ");
            char Answer = 'n';
            Answer = char.Parse(Console.ReadLine());

            if (Answer == 'Y' || Answer == 'y')
            {
                if (SourceClient.Transfer(Amount, ref DestinationClient,ref SourceClient))
                {
                    Console.WriteLine("Transfer done successfully");
                }
                else
                {
                    Console.WriteLine("Transfer Faild");
                }
            }

        }

    }
}
