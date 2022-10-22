using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Contexts;
using MagicVilla_VillaApi.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MagicVilla_VillaApi.Repositories
{
    public class VillaRepository :Repository<Villa>,IVillaRepository
    {
        private ApplicationDbContext _context;
        public VillaRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        //update  hemise ayri yazilar
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
           _context.Villas.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
