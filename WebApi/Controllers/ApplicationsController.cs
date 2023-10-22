using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.ApplicationDtos;
using Entities.Dtos.CarDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Common;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : BaseController
    {
        private readonly IApplicationService _applicationService;
        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("add")]
        public ActionResult Add(AddApplicationDto addApplicationDto)
        {
            var result = _applicationService.SubmitWithoutCar(addApplicationDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpDelete("delete")]
        public ActionResult Delete(DeleteApplicationDto deleteApplicationDto)
        {
            var result = _applicationService.Delete(deleteApplicationDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpPut("update")]
        public ActionResult Update(UpdateApplicationDto updateApplicationDto)
        {
            var result = _applicationService.Update(updateApplicationDto);
            return GetResultResponseBySuccessStatus(result);
        }

        [HttpGet("getlist")]
        public ActionResult GetList()
        {
            var result = _applicationService.GetList();
            return GetDataResultResponseBySuccessStatus<List<GetListApplicationDto>>(result);
        }
        
        [HttpGet("getbyid")]
        public ActionResult GetListById(int id)
        {
            var result = _applicationService.GetById(id);
            return GetDataResultResponseBySuccessStatus<List<GetListApplicationDto>>(result);
        }

        [HttpGet("getbydriverid")]
        public ActionResult GetListByDriverId(int id)
        {
            var result = _applicationService.GetByDriverId(id);
            return GetDataResultResponseBySuccessStatus<List<GetListApplicationDto>>(result);
        }
        
        [HttpGet("getbyoperationid")]
        public ActionResult GetListByOperationId(int operationId)
        {
            var result = _applicationService.GetByOperationId(operationId);
            return GetDataResultResponseBySuccessStatus<List<GetListApplicationDto>>(result);
        }
        
        [HttpGet("getlistbystatus")]
        public ActionResult GetListByStatus(int status)
        {
            var result = _applicationService.GetListByStatus(status);
            return GetDataResultResponseBySuccessStatus<List<GetListApplicationDto>>(result);
        }
    }
}
