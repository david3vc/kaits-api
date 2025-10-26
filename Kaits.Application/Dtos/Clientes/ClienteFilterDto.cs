namespace Kaits.Application.Dtos.Clientes
{
    public class ClienteFilterDto
    {
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Dni { get; set; }
        public bool? Estado { get; set; }
    }
}
