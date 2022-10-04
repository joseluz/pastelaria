using Pastels.Application.Repositories;
using Pastels.Persistence.DataStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastels.Persistence
{
    public class PastelRepository : IPastelRepository
    {
        private readonly IPastelDataStore dataStore;

        //public PastelRepository(IPastelDataStore dataStore)
        //{
        //    this.dataStore = dataStore;
        //}
    }
}
