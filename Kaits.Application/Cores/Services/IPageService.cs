using Kaits.Application.Cores.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.Application.Cores.Services
{
    public interface IPageService<TDto, TDtoFilter>
    {
        Task<PageResponse<TDto>> FindAllPaginatedAsync(PageRequest<TDtoFilter> request);
    }
}
