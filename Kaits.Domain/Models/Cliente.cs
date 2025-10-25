using Kaits.Domain.Cores.Models;

namespace Kaits.Domain.Models
{
    public class Cliente : CoreModel<int>
    {
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
    }
}
