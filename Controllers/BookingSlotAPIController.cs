using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleParkingAPI.Data;
using VehicleParkingAPI.Models.Dto;
using VehicleParkingAPI.Models;

namespace VehicleParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingSlotAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;


        public BookingSlotAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        #region Get All BookingSlot 
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<BookingSlot> objList = _db.BookingSlots.ToList();
                _response.Result = _mapper.Map<IEnumerable<BookingSlotDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Get Vehicle Category
        [HttpGet("{id}")]
        public ResponseDto Get([FromRoute] int id)
        {
            try
            {
                BookingSlot obj = _db.BookingSlots.First(u => u.BookingSlotID == id);
                _response.Result = _mapper.Map<BookingSlotDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Create BookingSlot
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromForm] BookingSlotDto bookingSlotDto)
        {
            try
            {
                BookingSlot bookingSlot = _mapper.Map<BookingSlot>(bookingSlotDto);
                _db.BookingSlots.Add(bookingSlot);
                _db.SaveChanges();

                _response.Result = _mapper.Map<BookingSlotDto>(bookingSlot);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Update BookingSlot
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromForm] BookingSlotDto bookingSlotDto)
        {
            try
            {
                BookingSlot bookingSlot = _mapper.Map<BookingSlot>(bookingSlotDto);

                _db.BookingSlots.Update(bookingSlot);
                _db.SaveChanges();

                _response.Result = _mapper.Map<BookingSlotDto>(bookingSlot);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Delete BookingSlot
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                BookingSlot obj = _db.BookingSlots.First(u => u.BookingSlotID == id);

                _db.BookingSlots.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion
    }
}
