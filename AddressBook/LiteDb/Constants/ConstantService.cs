using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;
using LiteDB;

namespace AddressBook.LiteDb.Constants
{
    public class ConstantService : IConstantService
    {
        private LiteDatabase _liteDb;
        private const string CollectionName = "Constants";

        public ConstantService(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public IEnumerable<Models.Constants> GetConstants()
        {
            var result = _liteDb.GetCollection<Models.Constants>(CollectionName)
                .FindAll();
            return result;
        }

        public int Insert(Models.Constants constants)
        {
            return _liteDb.GetCollection<Models.Constants>(CollectionName)
                .Insert(constants);
        }
    }
}
