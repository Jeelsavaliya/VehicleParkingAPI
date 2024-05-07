using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VehicleParkingAPI.Models;

namespace VehicleParkingAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //VehicleCategoryAPI
        public DbSet<VehicleCategory> VehicleCategorys { get; set; }

        //VehicleAPI
        public DbSet<Vehicle> Vehicles { get; set; }

        //SlotAreaAPI
        public DbSet<SlotArea> SlotAreas { get; set; }

        //BookingSlotAPI
        public DbSet<BookingSlot> BookingSlots { get; set; }


        //AuthAPI
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }
    }
}
