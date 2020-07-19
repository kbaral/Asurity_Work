using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string FullName => string.Concat(FirstName, " ", LastName);
        public string Email { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactFrequency { get; set; }
        public string PreferredContactMethod { get; set; }
    }
}
