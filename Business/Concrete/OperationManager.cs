using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.CarValidators;
using Business.ValidationRules.FluentValidation.OperationValidators;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Concrete;
using Entities.Concrete;
using Entities.Dtos.OperationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class OperationManager : IOperationService
{
    private readonly IOperationDal _operationDal;
    public OperationManager(IOperationDal operationDal)
    {
        _operationDal = operationDal;
    }
    [ValidationAspect(typeof(AddOperationDtoValidator))]
    public IResult Add(AddOperationDto addOperationDto)
    {
        Operation operation = new()
        {
            Name = addOperationDto.Name,
            Text = addOperationDto.Text
        };
        this.OnOperationCreated(operation);
        _operationDal.Add(operation);
        return new SuccessResult(Messages.SuccessOperationAdded);
    }
    public IResult Delete(DeleteOperationDto deleteOperationDto)
    {
        Operation operation = new()
        {
            Id = deleteOperationDto.Id
        };
        this.OnOperationDeleted(operation);
        _operationDal.Delete(operation);
        return new SuccessResult(Messages.SuccessOperationDeleted);
    }

    [ValidationAspect(typeof(UpdateOperationDtoValidator))]
    public IResult Update(UpdateOperationDto updateOperationDto)
    {
        Operation operation = _operationDal.Get(o => o.Id ==  updateOperationDto.Id);
        operation.Name = updateOperationDto.Name;
        operation.Text = updateOperationDto.Text;
        this.OnOperationUpdated(operation);
        _operationDal.Update(operation);
        return new SuccessResult(Messages.SuccessOperationUpdated);
    }

    public IDataResult<List<Operation>> GetList()
    {
        return new SuccessDataResult<List<Operation>>(_operationDal.GetList(), Messages.SuccessOperationsListed);
    }

    private void OnOperationCreated(Operation operation)
    {
        operation.CreatedDate = DateTime.Now;
    }
    private void OnOperationDeleted(Operation operation)
    {
        operation.DeletedDate = DateTime.Now;
    }
    private void OnOperationUpdated(Operation operation)
    {
        operation.UpdatedDate = DateTime.Now;
    }
}
