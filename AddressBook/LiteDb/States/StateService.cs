using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;
using LiteDB;

namespace AddressBook.LiteDb.States
{
    public class StateService : IStateService
    {
        private LiteDatabase _liteDb;
        private const string CollectionName = "States";

        public StateService(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public IEnumerable<State> FindAll()
        {
            var result = _liteDb.GetCollection<State>(CollectionName)
                .FindAll();
            return result;
        }

        public int Insert(State state)
        {
            return _liteDb.GetCollection<State>(CollectionName)
                .Insert(state);
        }
    }
}
