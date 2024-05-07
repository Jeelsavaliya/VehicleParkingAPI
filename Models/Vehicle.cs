using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleParkingAPI.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public int VehicleCategoryID { get; set; }
        [Column("VehicleCompany", TypeName = "nvarchar(50)")]
        [Required]
        public string VehicleCompany { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }

        [Column("Photo", TypeName = "nvarchar(500)")]
        public string? Image { get; set; } = String.Empty;

        [Column("VehicleModel", TypeName = "nvarchar(50)")]
        [Required]
        public string VehicleModel { get; set; }

        [Column("VehicleNumber", TypeName = "nvarchar(50)")]
        [Required]
        public string VehicleNumber { get; set; }

        [Column("OwnerName", TypeName = "nvarchar(50)")]
        [Required]
        public string OwnerName { get; set; }

        [Column("OwnerMobileNo", TypeName = "nvarchar(50)")]
        [Required]
        public string OwnerMobileNo { get; set; }


        //For ForeignKey
        [ForeignKey("VehicleCategoryID")]
        public VehicleCategory VehicleCategory { get; set; }
    }
}
