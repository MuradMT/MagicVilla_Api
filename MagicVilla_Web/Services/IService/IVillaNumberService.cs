using MagicVilla_Web.Models.Dtos;

namespace MagicVilla_Web.Services.IService
{
    public interface IVillaNumberService
    {
        Task<T> GetAsync<T>(int id, string token);
        Task<T> GetAllAsync<T>(string token);
        Task<T> CreateAsync<T>(VillaNumberCreateDto dto, string token);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto, string token);
        Task<T> DeleteAsync<T>(int id,string token);

    }
}
