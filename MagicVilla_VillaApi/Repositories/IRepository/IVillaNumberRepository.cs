using MagicVilla_VillaApi.Models;

namespace MagicVilla_VillaApi.Repositories.IRepository
{
    public interface IVillaNumberRepository:IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
