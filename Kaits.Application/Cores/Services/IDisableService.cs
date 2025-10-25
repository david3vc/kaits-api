namespace Kaits.Application.Cores.Services
{
    public interface IDisableService<TDto, ID>
    {
        Task<TDto> DisabledAsync(ID id);
    }
}
