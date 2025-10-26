namespace Kaits.Application.Dtos.Productos
{
    public class ProductoFilterDto
    {
        public string? Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public bool? Estado { get; set; }
    }
}
