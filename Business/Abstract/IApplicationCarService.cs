using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.ApplicationCarDtos;
using Entities.Dtos.ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IApplicationCarService
{
    IResult SubmitWithCar(AddApplicationCarDto addApplicationCarDto);
    IResult Delete(DeleteApplicationCarDto deleteApplicationCarDto);
    IResult Update(UpdateApplicationCarDto updateApplicationCarDto);
    IDataResult<List<GetListApplicationCarDto>> GetList();
    IDataResult<List<GetListApplicationCarDto>> GetById(int id);
    IDataResult<List<GetListApplicationCarDto>> GetByCarId(int carId);
    IDataResult<List<GetListApplicationCarDto>> GetByOperationId(int operationId);
}
