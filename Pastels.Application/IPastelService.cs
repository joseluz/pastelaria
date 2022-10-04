using Pastels.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastels.Application
{
    public interface IPastelService
    {
        Task<IEnumerable<Pastel>> FindAll();
    }
}
