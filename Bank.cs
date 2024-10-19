using Bank_System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Bank : Person
    {
        public string _AccountNumber { get; set; }
        public  double _AccountBalance { get; set; }
        public bool MarkForDeleted { get; set; }

        public static string ClientsFile = "FileClient.txt";

        
        public Bank(string AccountNumber, string FirstName, string LastName, string Email, string Phone, double AccountBalance)
            : base(FirstName, LastName, Email, Phone)
        {
            _AccountNumber = AccountNumber;
            _AccountBalance = AccountBalance;
        }

        

        public static string ReadString()
        {
            string? s;
            s = Console.ReadLine();
            return s;
        }
        public static double ReadDouble()
        {
            double d;
            d = double.Parse(Console.ReadLine());
            return d;
        }
        public static Bank ConvertLineToClientObject(string line, string sep = ",")
        {
            string[] sClients = line.Split(new[] { sep }, StringSplitOptions.None);
            return new Bank(sClients[0], sClients[1], sClients[2], sClients[3], sClients[4], double.Parse(sClients[5]));
        }
        public static string ConvertClientObjectToLine(Bank Client, string sep = ",")
        {
            string ClientRecord = "";
            ClientRecord += Client._AccountNumber + sep;
            ClientRecord += Client._FirstName + sep;
            ClientRecord += Client._LastName + sep;
            //ClientRecord += Client.GetFullName() + sep;
            ClientRecord += Client._Email + sep;
            ClientRecord += Client._Phone + sep;
            ClientRecord += Client._AccountBalance;
            return ClientRecord;
        }
        public static Bank GetEmptyClientObject()
        {
            return new Bank("", "", "", "", "", 0);
        }
        public static Bank Find(string accountNumber)
        {
            using (StreamReader file = new StreamReader(ClientsFile))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Bank Client = ConvertLineToClientObject(line);
                    if (Client._AccountNumber == accountNumber)
                    {
                        file.Close();
                        return Client;
                    }
                }
                file.Close();
            }
            return GetEmptyClientObject();
        }
        public static bool IsClientExit(string accountNumber)
        {
            Bank Clinet = Bank.Find(accountNumber);
            return (Clinet != null);
        }
        public static void _PrintClinet(Bank Client)
        {
            Console.WriteLine("Client Card");
            Console.WriteLine("=====================");
            Console.WriteLine($"Account Number: {Client._AccountNumber}");
            Console.WriteLine($"Full Name: {Client.GetFullName()}");
            Console.WriteLine($"Email: {Client._Email}");
            Console.WriteLine($"Phone: {Client._Phone}");
            Console.WriteLine($"Account Balance: {Client._AccountBalance}");
            Console.WriteLine("=====================");
        }
        public static List<Bank> _LoadClientsDataFromFile()
        {
            List<Bank> _list = new List<Bank>();

            if (File.Exists(ClientsFile))
            {
                using (StreamReader st = new StreamReader(ClientsFile))
                {
                    string line;
                    while ((line = st.ReadLine()) != null)
                    {
                        Bank Client1 = Bank.ConvertLineToClientObject(line);
                        _list.Add(Client1);
                    }
                    st.Close();
                }
            }
            return _list;
        }
        public static void _SaveCleintsDataToFile(List<Bank> _list)
        {
            using (StreamWriter st = new StreamWriter(ClientsFile, false))
            {
                foreach (Bank b in _list)
                {
                    if (!b.MarkForDeleted)
                    {
                        string DataLine = Bank.ConvertClientObjectToLine(b);
                        st.WriteLine(DataLine);
                    }
                    
                }
                st.Close();
            }
        }

        public void Deposit(double Amount, string AccountNumber)
        {
            _AccountBalance += Amount;
            List<Bank> list = new List<Bank>();
            list = _LoadClientsDataFromFile();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]._AccountNumber == AccountNumber)
                {
                    list[i] = this;
                    break;
                }
            }
            _SaveCleintsDataToFile(list);
        }

        public void Withdraw(double Amount,string AccountNumber)
        {
            _AccountBalance -= Amount;
            List<Bank> list = new List<Bank>();
            list = _LoadClientsDataFromFile();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]._AccountNumber == AccountNumber)
                {
                    list[i] = this;
                    break;
                }
            }
            _SaveCleintsDataToFile(list);
        }

        public bool Transfer(double Amount, ref Bank DestinationClient ,ref Bank SourceClient)
        {
            if(Amount > _AccountBalance)
            {
                return false;
            }
            else
            {
                Withdraw(Amount, SourceClient._AccountNumber);
                DestinationClient.Deposit(Amount, DestinationClient._AccountNumber);
                return true;
            }
        }

    }
}
