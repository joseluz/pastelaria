using Pastels.Api.Resources;
using Pastels.Persistence.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastels.Persistence.DataStores
{
    public interface IPastelDataStore : IDataStore<PastelDocument>
    {
    }
}
