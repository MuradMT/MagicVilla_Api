using MagicVilla_Web.Models.Dtos;

namespace MagicVilla_Web.Services.IService
{
    public interface IVillaService
    {
        Task<T> GetAsync<T>(int id);
        Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>(VillaCreateDto dto);
        Task<T> UpdateAsync<T>(VillaUpdateDto dto);
        Task<T> DeleteAsync<T>(int id);

    }
}
