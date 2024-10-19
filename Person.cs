using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Person
    {
        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        public string _Email { get; set; }
        public string _Phone { get; set; }

        public Person(string FirstName, string LastName, string Email, string Phone)
        {
            _FirstName = FirstName;
            _LastName = LastName;
            _Email = Email;
            _Phone = Phone;
        }
        public string GetFullName()
        {
            return _FirstName + " " + _LastName;
        }

    }
}
