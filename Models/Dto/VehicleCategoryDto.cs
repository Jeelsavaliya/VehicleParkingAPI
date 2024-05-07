using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleParkingAPI.Models.Dto
{
    public class VehicleCategoryDto
    {
        public int VehicleCategoryID { get; set; }
        public string VehicleCategoryName { get; set; }
    }
}
