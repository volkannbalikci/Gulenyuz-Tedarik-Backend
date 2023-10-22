using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.CarDtos;
using Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Common;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getlist")]
        public ActionResult GetList()
        {
            var result = _carService.GetList();
            return GetDataResultResponseBySuccessStatus<List<Car>>(result);
        }

        [HttpPost("add")]
        public ActionResult Add(AddCarDto addCarDto)
        {
            var result = _carService.Add(addCarDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpDelete("delete")]
        public ActionResult Delete(DeleteCarDto deleteCarDto)
        {
            var result = _carService.Delete(deleteCarDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpPut("update")]
        public ActionResult Update(UpdateCarDto updateCarDto)
        {
            var result = _carService.Update(updateCarDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpGet("getbyid")]
        public ActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            return GetDataResultResponseBySuccessStatus<Car>(result);
        }

        [HttpGet("getbybrand")]
        public ActionResult GetByBrand(string brand)
        {
            var result = _carService.GetByBrand(brand);
            return GetDataResultResponseBySuccessStatus<List<Car>>(result);
        }

        [HttpGet("getbymodel")]
        public ActionResult GetByModel(string model)
        {
            var result = _carService.GetByModel(model);
            return GetDataResultResponseBySuccessStatus<List<Car>>(result);
        }

        [HttpGet("getbyenginedisplacemment")]
        public ActionResult GetByEngineDisplacement(string engineDisplacemment)
        {
            var result = _carService.GetByEngineDisplacement(engineDisplacemment);
            return GetDataResultResponseBySuccessStatus<List<Car>>(result);
        }

        [HttpGet("getbyyear")]
        public ActionResult GetByYear(int year)
        {
            var result = _carService.GetByYear(year);
            return GetDataResultResponseBySuccessStatus<List<Car>>(result);
        }

        [HttpGet("getbyhp")]
        public ActionResult GetByHp(string hp)
        {
            var result = _carService.GetByHp(hp);
            return GetDataResultResponseBySuccessStatus<List<Car>>(result);
        }

        [HttpGet("getbycartype")]
        public ActionResult GetByCarType(ChasisType chasisType)
        {
            var result = _carService.GetByCarType(chasisType);
            return GetDataResultResponseBySuccessStatus<List<Car>>(result);
        }

        [HttpGet("getbyHasFrigo")]
        public ActionResult GetByHasFrigo(bool hasFrigo)
        {
            var result = _carService.GetByHasFrigo(hasFrigo);
            return GetDataResultResponseBySuccessStatus<List<Car>>(result);
        }
    }
}
