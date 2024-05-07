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
    public class VehicleAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;


        public VehicleAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        #region Get All Vehicle 
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Vehicle> objList = _db.Vehicles.ToList();
                _response.Result = _mapper.Map<IEnumerable<VehicleDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Get Roomtypw
        [HttpGet("{id}")]
        public ResponseDto Get([FromRoute] int id)
        {
            try
            {
                Vehicle obj = _db.Vehicles.First(u => u.VehicleID == id);
                _response.Result = _mapper.Map<VehicleDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Create Vehicle
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromForm] VehicleDto vehicleDto)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(vehicleDto);
                _db.Vehicles.Add(vehicle);
                _db.SaveChanges();

                if (vehicleDto.File != null)
                {
                    if (!string.IsNullOrEmpty(vehicle.Image))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), vehicle.Image);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }

                    string fileName = vehicle.VehicleID + Path.GetExtension(vehicleDto.File.FileName);
                    string filePath = @"wwwroot\VehicleImages\" + fileName;
                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        vehicleDto.File.CopyTo(fileStream);
                    }
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    vehicle.Image = "/VehicleImages/" + fileName;
                }
                else
                {
                    vehicle.Image = "https://placehold.co/600x400";
                }
                _db.Vehicles.Update(vehicle);
                _db.SaveChanges();
                _response.Result = _mapper.Map<VehicleDto>(vehicle);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Update Vehicle
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromForm] VehicleDto vehicleDto)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(vehicleDto);

                if (vehicleDto.File != null)
                {
                    if (!string.IsNullOrEmpty(vehicle.Image))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), vehicle.Image);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }

                    string fileName = vehicle.VehicleID + Path.GetExtension(vehicleDto.File.FileName);
                    string filePath = @"wwwroot/VehicleImages/" + fileName;
                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        vehicleDto.File.CopyTo(fileStream);
                    }
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    vehicle.Image = "/VehicleImages/" + fileName;
                    /*vehicle.Image = filePath;*/
                }

                _db.Vehicles.Update(vehicle);
                _db.SaveChanges();

                _response.Result = _mapper.Map<VehicleDto>(vehicle);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Delete Vehicle
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Vehicle obj = _db.Vehicles.First(u => u.VehicleID == id);
                if (!string.IsNullOrEmpty(obj.Image))
                {
                    var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), obj.Image);
                    FileInfo file = new FileInfo(oldFilePathDirectory);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                _db.Vehicles.Remove(obj);
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
