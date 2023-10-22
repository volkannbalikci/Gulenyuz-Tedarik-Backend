using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.DriverDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Common;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : BaseController
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost("add")]
        public ActionResult Add(AddDriverDto addDriverDto)
        {
            var result = _driverService.Add(addDriverDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpPut("update")]
        public ActionResult Update(UpdateDriverDto updateDriverDto)
        {
            var result = _driverService.Update(updateDriverDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpDelete("delete")]
        public ActionResult Delete(DeleteDriverDto deleteDriverDto)
        {
            var result = _driverService.Delete(deleteDriverDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpGet("getlist")]
        public ActionResult GetList()
        {
            var result = _driverService.GetList();
            return GetDataResultResponseBySuccessStatus(result);
        }
        
        [HttpGet("getlistbyıd")]
        public ActionResult GetListById(int id)
        {
            var result = _driverService.GetById(id);
            return GetDataResultResponseBySuccessStatus(result);
        }

        [HttpGet("getlistbyname")]
        public ActionResult GetListByName(string name)
        {
            var result = _driverService.GetByName(name);
            return GetDataResultResponseBySuccessStatus(result);
        }

        [HttpGet("getlistbylastname")]
        public ActionResult GetListByLastName(string lastName)
        {
            var result = _driverService.GetByLastName(lastName);
            return GetDataResultResponseBySuccessStatus(result);
        }

        [HttpGet("getlistbyemail")]
        public ActionResult GetListByEmail(string email)
        {
            var result = _driverService.GetByEmail(email);
            return GetDataResultResponseBySuccessStatus(result);
        }

        [HttpGet("getlistbyphonenumber")]
        public ActionResult GetListByPhoneNumber(string phoneNumber)
        {
            var result = _driverService.GetByPhoneNumber(phoneNumber);
            return GetDataResultResponseBySuccessStatus(result);
        }
        
        [HttpGet("getlistbyhassrc")]
        public ActionResult GetListByHasSrc(bool hasSrc)
        {
            var result = _driverService.GetByHasSrc(hasSrc);
            return GetDataResultResponseBySuccessStatus(result);
        }
    }
}
