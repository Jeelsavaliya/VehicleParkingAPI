using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleParkingAPI.Models.Dto
{
    public class SlotAreaDto
    {
        public int SlotAreaID { get; set; }
        public int VehicleCategoryID { get; set; }
        public string SlotAreaName { get; set; }
        public IFormFile File { get; set; }
        public string? Image { get; set; } = String.Empty;
        public string BuildingName { get; set; }
        public string SlotAreaCode { get; set; }
        public string Status { get; set; }
        public string Price { get; set; }
    }
}
