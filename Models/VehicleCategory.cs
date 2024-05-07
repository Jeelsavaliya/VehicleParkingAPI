using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleParkingAPI.Models
{
    public class VehicleCategory
    {
        [Key]
        public int VehicleCategoryID { get; set; }

        [Column("VehicleCategory", TypeName = "nvarchar(50)")]
        [Required]
        public string VehicleCategoryName { get; set; }
        
    }
}
