using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Clients
{
    internal class Clients : Bank
    {
        public Clients(string AccountNumber, string FirstName, string LastName, string Email, string Phone, double AccountBalance) : base(AccountNumber, FirstName, LastName, Email, Phone, AccountBalance)
        {
        }
        #region Add New Client
        private static Bank GetAddNewClientOdject(string accountNumber)
        {
            return new Bank(accountNumber, "", "", "", "", 0);
        }
        private static void ReadNewClient(ref Bank Client)
        {
            Console.WriteLine("Enter First Name: ");
            Client._FirstName = ReadString();

            Console.WriteLine("Enter Last Name: ");
            Client._LastName = ReadString();

            Console.WriteLine("Enter Email: ");
            Client._Email = ReadString();

            Console.WriteLine("Enter Phone: ");
            Client._Phone = ReadString();

            Console.WriteLine("Enter Account Balance: ");
            Client._AccountBalance = ReadDouble();
        }
        private static void AddDataLineToFile(string DataLine)
        {
            using (StreamWriter writer = new StreamWriter(ClientsFile, true))
            {
                writer.WriteLine(DataLine);
                writer.Close();
            }
            Console.WriteLine("Client Added Successfully");
        }
        public static void AddNewClient()
        {
            Console.WriteLine("Add New Client Screen");
            string AccountNumber;
            Console.Write("Enter The Account Number: ");
            AccountNumber = ReadString();

            while (!IsClientExit(AccountNumber))
            {
                Console.Write("Account Number is Already Used, Choose another one: ");
                AccountNumber = ReadString();
            }
            Bank NewClient = GetAddNewClientOdject(AccountNumber);
            ReadNewClient(ref NewClient);
            AddDataLineToFile(ConvertClientObjectToLine(NewClient));
        }
        #endregion

        #region Update Client
        public static void UpdataClient()
        {
            Console.WriteLine("Updata Client Screen");
            string AccountNumber;
            Console.Write("Enter The Account Number: ");
            AccountNumber = ReadString();

            while (!IsClientExit(AccountNumber))
            {
                Console.Write("Account Number is Not Used, Choose another one: ");
                AccountNumber = ReadString();
            }
            Bank Client1 = Find(AccountNumber);
            _PrintClinet(Client1);

            Console.Write("Are You Sure You Want To Update This Client Y/N ? : ");
            int s = Console.Read();
            char c = (char)s;
            if (c == 'Y' || c == 'y')
            {
                Console.WriteLine("Update Client");
                Console.WriteLine("=====================");
                ReadNewClient(ref Client1);

                List<Bank> list = new List<Bank>();
                list = _LoadClientsDataFromFile();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i]._AccountNumber == AccountNumber)
                    {
                        list[i] = Client1;
                        break;
                    }
                }
                _SaveCleintsDataToFile(list);
                Console.WriteLine("Client Updated Successfully");
            }

        }
        #endregion

        #region Delete Client
        public static void DeleteClient()
        {
            Console.WriteLine("Delete Client Screen");
            string AccountNumber;
            Console.Write("Enter Account Number ");
            AccountNumber = ReadString();

            while (!IsClientExit(AccountNumber))
            {
                Console.Write("Account Number is Not Used, Choose another one: ");
                AccountNumber = ReadString();
            }
            Bank Client = Find(AccountNumber);
            _PrintClinet(Client);

            Console.Write("Are You Sure You Want To Delete This Client Y/N ? : ");
            int s = Console.Read();
            char c = (char)s;
            if (c == 'Y' || c == 'y')
            {
                Console.WriteLine("Delete Screen");
                Console.WriteLine("=====================");

                List<Bank> clients = _LoadClientsDataFromFile();

                foreach (Bank client in clients)
                {
                    if (client._AccountNumber == AccountNumber)
                    {

                        client.MarkForDeleted = true;
                        break;
                    }
                }
                _SaveCleintsDataToFile(clients);
                Client = GetEmptyClientObject();
                Console.WriteLine("Client Deleted Successfully");

            }
        }
        #endregion

        #region Find Client
        public static void FindClient()
        {
            Console.WriteLine("Find Client Screen");
            string AccountNumber;
            Console.Write("Enter The Account Number: ");
            AccountNumber = ReadString();

            while (!IsClientExit(AccountNumber))
            {
                Console.Write("Account Number is Not Used, Choose another one: ");
                AccountNumber = ReadString();
            }
            Bank Client = Find(AccountNumber);
            _PrintClinet(Client);
        }
        #endregion

        #region ShowAllClients

        private static void PrintClientRecordLine(Bank client)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-12} | {3,-20} | {4,-10}",
                            client._AccountNumber,
                            client.GetFullName(),
                            client._Phone,
                            client._Email,
                            client._AccountBalance);
        }
        public static void ShowAllClients()
        {
            List<Bank> Clients = new List<Bank>();
            Clients = _LoadClientsDataFromFile();

            Console.WriteLine($"\t=========================== List Of {Clients.Count} Clients ===========================\n\n");

            Console.WriteLine("{0,-15} | {1,-20} | {2,-12} | {3,-20} | {4,-10}",
                "Account Number", "Client Name", "Phone", "Email", "Balance");

            Console.WriteLine("________________________________________________________________________________________");
            Console.WriteLine("________________________________________________________________________________________\n");


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

            Console.WriteLine("________________________________________________________________________________________");
            Console.WriteLine("________________________________________________________________________________________");
        }
        #endregion

    }
}
