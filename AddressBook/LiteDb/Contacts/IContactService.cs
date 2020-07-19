using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.LiteDb
{
    public interface IContactService
    {
        bool Delete(int id);
        IEnumerable<Contact> FindAll();
        Contact FindOne(int id);
        int Insert(Contact contact);
        bool Update(Contact contact);
    }
}
