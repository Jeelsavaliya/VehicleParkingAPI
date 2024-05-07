using AutoMapper;
using VehicleParkingAPI.Models;
using VehicleParkingAPI.Models.Dto;

namespace VehicleParkingAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VehicleCategoryDto, VehicleCategory>().ReverseMap();
                config.CreateMap<VehicleDto, Vehicle>().ReverseMap();
                config.CreateMap<SlotAreaDto, SlotArea>().ReverseMap();
                config.CreateMap<BookingSlotDto, BookingSlot>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
