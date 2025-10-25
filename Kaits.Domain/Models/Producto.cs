using Kaits.Domain.Cores.Models;

namespace Kaits.Domain.Models
{
    public class Producto : CoreModel<int>
    {
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
