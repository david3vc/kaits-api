namespace Kaits.Application.Dtos.Clientes
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool Estado { get; set; }
    }
}
