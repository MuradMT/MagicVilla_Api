using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;

namespace MagicVilla_VillaApi.Repositories.IRepository
{
    public interface IVillaRepository:IRepository<Villa>
    {
        
        Task UpdateAsync(Villa entity);
      
    }
}
