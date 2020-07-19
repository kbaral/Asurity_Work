using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.LiteDb.Constants
{
    public interface IConstantService
    {
        IEnumerable<Models.Constants> GetConstants();
        int Insert(Models.Constants constants);
    }
}
