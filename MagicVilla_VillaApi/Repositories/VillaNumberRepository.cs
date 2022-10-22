using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Contexts;
using MagicVilla_VillaApi.Repositories.IRepository;
using System.Linq.Expressions;

namespace MagicVilla_VillaApi.Repositories
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private ApplicationDbContext _context;
        public VillaNumberRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedTime = DateTime.Now;
             _context.VillaNumbers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
            
        }
    }
}
