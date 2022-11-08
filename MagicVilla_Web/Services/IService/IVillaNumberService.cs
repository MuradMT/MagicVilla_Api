using MagicVilla_Web.Models.Dtos;

namespace MagicVilla_Web.Services.IService
{
    public interface IVillaNumberService
    {
        Task<T> GetAsync<T>(int id);
        Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>(VillaNumberCreateDto dto);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto);
        Task DeleteAsync<T>(int id);

    }
}
