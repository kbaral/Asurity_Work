using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.LiteDb.States
{
    public interface IStateService
    {
        IEnumerable<State> FindAll();
        int Insert(State state);
    }
}
