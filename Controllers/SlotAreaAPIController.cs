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
    public class SlotAreaAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;


        public SlotAreaAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        #region Get All SlotAreas
        [HttpGet]

        public ResponseDto Get()
        {
            try
            {
                IEnumerable<SlotArea> objList = _db.SlotAreas.ToList();
                _response.Result = _mapper.Map<IEnumerable<SlotAreaDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Gett SlotArea
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                SlotArea obj = _db.SlotAreas.First(u => u.SlotAreaID == id);
                _response.Result = _mapper.Map<SlotAreaDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Create SlotAreas
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromForm] SlotAreaDto slotAreaDto)
        {
            try
            {
                SlotArea slotArea = _mapper.Map<SlotArea>(slotAreaDto);
                _db.SlotAreas.Add(slotArea);
                _db.SaveChanges();

                if (slotAreaDto.File != null)
                {
                    if (!string.IsNullOrEmpty(slotArea.Image))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), slotArea.Image);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }

                    string fileName = slotArea.SlotAreaID + Path.GetExtension(slotAreaDto.File.FileName);
                    string filePath = @"wwwroot\SlotAreaImages\" + fileName;
                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        slotAreaDto.File.CopyTo(fileStream);
                    }
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    slotArea.Image = "/SlotAreaImages/" + fileName;

                }
                else
                {
                    slotArea.Image = "https://placehold.co/600x400";
                }
                _db.SlotAreas.Update(slotArea);
                _db.SaveChanges();
                _response.Result = _mapper.Map<SlotAreaDto>(slotArea);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Update SlotArea
        [HttpPut]
        [Authorize(Roles = "ADMIN,CUSTOMER")]
        public ResponseDto Put([FromForm] SlotAreaDto slotAreaDto)
        {
            try
            {
                SlotArea slotArea = _mapper.Map<SlotArea>(slotAreaDto);
                if (slotAreaDto.File != null)
                {
                    if (!string.IsNullOrEmpty(slotArea.Image))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), slotArea.Image);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }

                    string fileName = slotArea.SlotAreaID + Path.GetExtension(slotAreaDto.File.FileName);
                    string filePath = @"wwwroot\SlotAreaImages\" + fileName;
                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        slotAreaDto.File.CopyTo(fileStream);
                    }
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    slotArea.Image = "/SlotAreaImages/" + fileName;
                }
                _db.SlotAreas.Update(slotArea);
                _db.SaveChanges();

                _response.Result = _mapper.Map<SlotAreaDto>(slotArea);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        #endregion

        #region Delete SlotArea
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                SlotArea obj = _db.SlotAreas.First(u => u.SlotAreaID == id);
                if (!string.IsNullOrEmpty(obj.Image))
                {
                    var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), obj.Image);
                    FileInfo file = new FileInfo(oldFilePathDirectory);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                _db.SlotAreas.Remove(obj);
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
