using Pastels.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastels.Application.Repositories
{
    public interface IPastelRepository
    {
        Task<IEnumerable<Pastel>> FindAll();
    }
}
