using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleParkingAPI.Models.Dto
{
    public class BookingSlotDto
    {
        public int BookingSlotID { get; set; }
        public int VehicleID { get; set; }
        public int SlotAreaID { get; set; }
        public string? BookingDate { get; set; }
        public string? EntryTime { get; set; }
        public string? ExitTime { get; set; }
        public string? Remark { get; set; }
        public decimal? Amount { get; set; }
    }
}
