using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.ApplicationCarDtos;
using Entities.Dtos.ApplicationDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Common;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationCarsController : BaseController
    {
        private readonly IApplicationCarService _applicationCarService;
        public ApplicationCarsController(IApplicationCarService applicationCarService)
        {
            _applicationCarService = applicationCarService;
        }

        [HttpPost("add")]
        public ActionResult Add(AddApplicationCarDto addApplicationCarDto)
        {
            var result = _applicationCarService.SubmitWithCar(addApplicationCarDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpDelete("delete")]
        public ActionResult Delete(DeleteApplicationCarDto deleteApplicationCarDto)
        {
            var result = _applicationCarService.Delete(deleteApplicationCarDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpPut("update")]
        public ActionResult Update(UpdateApplicationCarDto updateApplicationCarDto)
        {
            var result = _applicationCarService.Update(updateApplicationCarDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpGet("getlist")]
        public ActionResult GetList()
        {
            var result = _applicationCarService.GetList();
            return GetDataResultResponseBySuccessStatus<List<GetListApplicationCarDto>>(result);
        }
        
        [HttpGet("getbyapplicationcarid")]
        public ActionResult GetById(int id)
        {
            var result = _applicationCarService.GetById(id);
            return GetDataResultResponseBySuccessStatus<List<GetListApplicationCarDto>>(result);
        }
        
        [HttpGet("getbycarid")]
        public ActionResult GetByCarId(int carId)
        {
            var result = _applicationCarService.GetByCarId(carId);
            return GetDataResultResponseBySuccessStatus<List<GetListApplicationCarDto>>(result);
        }      

        [HttpGet("getbyoperationid")]
        public ActionResult GetByOperationId(int operationId)
        {
            var result = _applicationCarService.GetByOperationId(operationId);
            return GetDataResultResponseBySuccessStatus<List<GetListApplicationCarDto>>(result);
        }      
    }
}
