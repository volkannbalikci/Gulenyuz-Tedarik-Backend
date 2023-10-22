using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.ApplicationCarDtos;
using Entities.Dtos.ApplicationDtos;
using Entities.Dtos.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IApplicationService
{
    IResult SubmitWithoutCar(AddApplicationDto addApplicationDto);
    IResult Delete(DeleteApplicationDto deleteApplicationDto);
    IResult Update(UpdateApplicationDto updateApplicationDto);
    IDataResult<List<GetListApplicationDto>> GetList();
    IDataResult<List<GetListApplicationDto>> GetById(int id);
    IDataResult<List<GetListApplicationDto>> GetByDriverId(int driverId);
    IDataResult<List<GetListApplicationDto>> GetByOperationId(int operationId);
    IDataResult<List<GetListApplicationDto>> GetListByStatus(int status);
}
