using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleParkingAPI.Models
{
    public class SlotArea
    {
        [Key]
        public int SlotAreaID { get; set; }
        public int VehicleCategoryID { get; set; }
        [Column("BuildingName", TypeName = "nvarchar(50)")]
        public string BuildingName { get; set; }
        [Column("SlotAreaName", TypeName = "nvarchar(50)")]
        [Required]
        public string SlotAreaName { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }

        [Column("Photo", TypeName = "nvarchar(500)")]
        public string? Image { get; set; } = String.Empty;

        [Column("SlotAreaCode", TypeName = "nvarchar(50)")]
        public string SlotAreaCode { get; set; }

        [Column("Status", TypeName = "nvarchar(50)")]
        public string Status { get; set; }

        [Column("Price", TypeName = "decimal(10,2)")]
        public decimal? Price { get; set; }


        //For ForeignKey
        [ForeignKey("VehicleCategoryID")]
        public VehicleCategory VehicleCategory { get; set; }
    }
}
