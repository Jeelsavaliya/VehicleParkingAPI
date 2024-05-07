using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleParkingAPI.Data;
using VehicleParkingAPI.Models;
using VehicleParkingAPI.Models.Dto;

namespace VehicleParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleCategoryAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;


        public VehicleCategoryAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        #region Get All VehicleCategory 
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<VehicleCategory> objList = _db.VehicleCategorys.ToList();
                _response.Result = _mapper.Map<IEnumerable<VehicleCategoryDto>>(objList);
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
                VehicleCategory obj = _db.VehicleCategorys.First(u => u.VehicleCategoryID == id);
                _response.Result = _mapper.Map<VehicleCategoryDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Create VehicleCategory
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromForm] VehicleCategoryDto vehicleCategoryDto)
        {
            try
            {
                VehicleCategory vehicleCategory = _mapper.Map<VehicleCategory>(vehicleCategoryDto);
                _db.VehicleCategorys.Add(vehicleCategory);
                _db.SaveChanges();

                _response.Result = _mapper.Map<VehicleCategoryDto>(vehicleCategory);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Update VehicleCategory
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromForm] VehicleCategoryDto vehicleCategoryDto)
        {
            try
            {
                VehicleCategory vehicleCategory = _mapper.Map<VehicleCategory>(vehicleCategoryDto);

                _db.VehicleCategorys.Update(vehicleCategory);
                _db.SaveChanges();

                _response.Result = _mapper.Map<VehicleCategoryDto>(vehicleCategory);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Delete VehicleCategory
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                VehicleCategory obj = _db.VehicleCategorys.First(u => u.VehicleCategoryID == id);
               
                _db.VehicleCategorys.Remove(obj);
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
