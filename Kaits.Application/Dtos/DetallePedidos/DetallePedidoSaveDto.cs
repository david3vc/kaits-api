namespace Kaits.Application.Dtos.DetallePedidos
{
    public class DetallePedidoSaveDto
    {
        public int? Id { get; set; }
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
