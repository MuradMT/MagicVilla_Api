using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaApi.Models.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "this villa is nice",
                    ImageUrl = @"https://media-cdn.tripadvisor.com/media/vr-splice-j/09/1f/7e/d1.jpg",
                    Rate = 200,
                    Occupancy=4,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                 new Villa()
                 {
                     Id = 2,
                     Name = "Premium Pool Villa",
                     Details = "this villa is very good",
                     ImageUrl = @"https://images.squarespace-cdn.com/content/v1/585562bcbe659442d503893f/c3b765c0-45e3-46b3-9ff9-b4101fb30674/01.+Exotik+Villas+Bali+-+Aloui.jpg?format=1000w",
                     Rate = 400,
                     Occupancy = 5,
                     Sqft = 650,
                     Amenity = "",
                     CreatedDate = DateTime.Now
                 },
                 new Villa()
                 {
                     Id = 3,
                     Name = "Luxury Pool Villa",
                     Details = "this villa is very good and also exspensive",
                     ImageUrl = @"https://cf.bstatic.com/xdata/images/hotel/max1024x768/306027131.jpg?k=9bb7b6bfeab68dafed1919b814c007658b002eb2c94d65b59cc15bec83e04bfe&o=&hp=1",
                     Rate = 500,
                     Occupancy = 6,
                     Sqft = 750,
                     Amenity = "",
                     CreatedDate = DateTime.Now
                 },
                 new Villa()
                 {
                     Id = 4,
                     Name = "Diamond  Villa",
                     Details = "this villa is very good and also exspensive and  height is big",
                     ImageUrl = @"https://www.casagrand.co.in/wp-content/uploads/2021/06/1621872930952_florella.jpg",
                     Rate = 600,
                     Occupancy = 7,
                     Sqft = 850,
                     Amenity = "",
                     CreatedDate = DateTime.Now
                 },
                  new Villa()
                  {
                      Id = 5,
                      Name = "Diamond Pool Villa",
                      Details = "this villa is very good and also exspensive and  height&weight is big",
                      ImageUrl = @"https://storage.googleapis.com/bd-az-01/buildings-v2/2560x1920/1760.jpg",
                      Rate = 700,
                      Occupancy = 8,
                      Sqft = 950,
                      Amenity = "",
                      CreatedDate = DateTime.Now
                  }
                );
            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber()
                {
                    VillaId = 1,
                    VillaNo = 1,
                    SpecialDetails = "very good",
                    Villa = null
                }
                ); ;

        }
    }
}
