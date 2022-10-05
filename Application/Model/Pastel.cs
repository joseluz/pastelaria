using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    public class Pastel
    {
        public string Flavor { get; set; }
        public bool IsSweet { get; set; }
        public string? Ingredients { get; set; }
        public decimal CurrentPrice { get; set; }

        public Pastel(string flavor)
        {
            Flavor = flavor;
        }
    }
}
