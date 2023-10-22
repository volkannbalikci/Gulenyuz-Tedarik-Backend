using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.OperationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IOperationService
{
    IResult Add(AddOperationDto addOperationDto);
    IResult Update(UpdateOperationDto updateOperationDto);
    IResult Delete(DeleteOperationDto deleteOperationDto);
    IDataResult<List<Operation>> GetList();
}
