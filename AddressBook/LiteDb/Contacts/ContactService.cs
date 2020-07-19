using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.LiteDb
{
    public class ContactService : IContactService
    {
        private LiteDatabase _liteDb;
        private const string CollectionName = "Contacts";

        public ContactService(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public IEnumerable<Contact> FindAll()
        {
            var result = _liteDb.GetCollection<Contact>(CollectionName)
                .FindAll().OrderBy(c => c.FirstName);
            return result;
        }

        public Contact FindOne(int id)
        {
            return _liteDb.GetCollection<Contact>(CollectionName)
                .Find(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(Contact contact)
        {
            return _liteDb.GetCollection<Contact>(CollectionName)
                .Insert(contact);
        }

        public bool Update(Contact contact)
        {
            return _liteDb.GetCollection<Contact>(CollectionName)
                .Update(contact);
        }

        public bool Delete(int id)
        {
            return _liteDb.GetCollection<Contact>(CollectionName)
                .Delete(new LiteDB.BsonValue(id));
        }
    }

}