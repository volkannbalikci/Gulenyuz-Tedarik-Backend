using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.OperationDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationsController : BaseController
{
    private readonly IOperationService _operationService;

    public OperationsController(IOperationService operationService)
    {
        _operationService = operationService;
    }

    [HttpPost("add")]
    public ActionResult Add(AddOperationDto addOperationDto)
    {
        var result = _operationService.Add(addOperationDto);
        return GetResultResponseBySuccessStatus(result);
    }

    [HttpPut("update")]
    public ActionResult Update(UpdateOperationDto updateOperationDto)
    {
        var result = _operationService.Update(updateOperationDto);
        return GetResultResponseBySuccessStatus(result);
    }

    [HttpDelete("delete")]
    public ActionResult Delete(DeleteOperationDto deleteOperationDto)
    {
        var result = _operationService.Delete(deleteOperationDto);
        return GetResultResponseBySuccessStatus(result);
    }

    [HttpGet("getlist")]
    public ActionResult GetList()
    {
        var result = _operationService.GetList();
        return GetDataResultResponseBySuccessStatus(result);
    }

}