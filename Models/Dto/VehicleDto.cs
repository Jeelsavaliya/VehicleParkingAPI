using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleParkingAPI.Models.Dto
{
    public class VehicleDto
    {
        public int VehicleID { get; set; }
        public int VehicleCategoryID { get; set; }
        public string VehicleCompany { get; set; }
        public IFormFile? File { get; set; }
        public string? Image { get; set; } = String.Empty;
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }
        public string OwnerName { get; set; }
        public string OwnerMobileNo { get; set; }
    }
}
