using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleParkingAPI.Models
{
    public class BookingSlot
    {
        [Key]
        public int BookingSlotID { get; set; }
        public int VehicleID { get; set; }
        public int SlotAreaID { get; set; }
        [Column("BookingDate", TypeName = "date")]
        public string? BookingDate { get; set; }
        [Column("EntryTime", TypeName = "datetime")]
        public string? EntryTime { get; set; }
        [Column("ExitTime", TypeName = "datetime")]
        public string? ExitTime { get; set; }

        [Column("Remark", TypeName = "nvarchar(50)")]
        public string? Remark { get; set; }

        [Column("Amount", TypeName = "decimal(10,2)")]
        public decimal? Amount { get; set; }


        //For ForeignKey
        [ForeignKey("VehicleID")]
        public Vehicle Vehicle { get; set; }
        [ForeignKey("SlotAreaID")]
        public SlotArea SlotArea { get; set; }
    }
}
