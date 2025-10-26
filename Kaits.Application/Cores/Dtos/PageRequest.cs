using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.Application.Cores.Dtos
{
    public class PageRequest<T>
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public T? Filter { get; set; }
    }
}
