using Microsoft.AspNetCore.Identity;

namespace VehicleParkingAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
