using Kaits.Domain.Cores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.Domain.Models
{
    public class Pedido : CoreModel<int>
    {
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
