using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    public class OrderItem
    {
        public Pastel Pastel { get; set; }

        public decimal Price { get; set; }

        public OrderItem(Pastel pastel)
        {
            Pastel = pastel;
        }
    }
}
