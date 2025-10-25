namespace Kaits.Domain.Cores.Models
{
    public abstract class CoreModel<ID>
    {
        public ID Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool State { get; set; }
    }
}
