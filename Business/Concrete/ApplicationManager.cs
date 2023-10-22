using Azure;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos.ApplicationCarDtos;
using Entities.Dtos.ApplicationDtos;
using Entities.Dtos.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationDal _applicationDal;
    public ApplicationManager(IApplicationDal applicationDal)
    {
        _applicationDal = applicationDal;
    }

    public IResult SubmitWithoutCar(AddApplicationDto addApplicationDto)
    {
        Application application = new()
        {
            DriverId = addApplicationDto.DriverId,
            OperationId = addApplicationDto.OperationId,
            Status = addApplicationDto.Status
        };
        this.OnApplicationAdded(application);
        _applicationDal.Add(application);
        return new SuccessResult(Messages.SuccessApplicationAdded);
    }

    public IResult Delete(DeleteApplicationDto deleteApplicationDto)
    {
        Application application = new()
        {
            Id = deleteApplicationDto.Id
        };
        this.OnApplicationDeleted(application);
        _applicationDal.Delete(application);
        return new SuccessResult(Messages.SuccessApplicationDeleted);
    }

    public IDataResult<List<GetListApplicationDto>> GetByDriverId(int driverId)
    {
        using (var context = new GulenyuzTedarikContext())
        {
            var query = context.Applications.Where(a => a.DriverId == driverId)
                .Join(context.Drivers,
                application => application.DriverId,
                driver => driver.Id,
                (application, Driver) => new GetListApplicationDto
                {
                    Id = application.Id,
                    DriverId = Driver.Id,
                    status = application.Status,
                    OperationId = application.OperationId,
                    FirstName = Driver.FirstName,
                    LastName = Driver.LastName,
                    Address = Driver.Address,
                    PhoneNumber = Driver.PhoneNumber,
                    Email = Driver.Email,
                    HasSrc = Driver.HasSrc,
                    CreatedDate = Driver.CreatedDate,
                    UpdatedDate = Driver.UpdatedDate,
                    DeletedDate = Driver.DeletedDate
                });
            List<GetListApplicationDto> result = query.ToList();
            return new SuccessDataResult<List<GetListApplicationDto>>(result, Messages.SuccessApplicationListed);
        }
    }

    public IDataResult<List<GetListApplicationDto>> GetById(int id)
    {
        using (var context = new GulenyuzTedarikContext())
        {
            var query = context.Applications.Where(a => a.Id == id)
                .Join(context.Drivers,
                application => application.DriverId,
                driver => driver.Id,
                (application, Driver) => new GetListApplicationDto
                {
                    Id = application.Id,
                    DriverId = Driver.Id,
                    status = application.Status,
                    OperationId = application.OperationId,
                    FirstName = Driver.FirstName,
                    LastName = Driver.LastName,
                    Address = Driver.Address,
                    PhoneNumber = Driver.PhoneNumber,
                    Email = Driver.Email,
                    HasSrc = Driver.HasSrc,
                    CreatedDate = Driver.CreatedDate,
                    UpdatedDate = Driver.UpdatedDate,
                    DeletedDate = Driver.DeletedDate
                });
            List<GetListApplicationDto> result = query.ToList();
            return new SuccessDataResult<List<GetListApplicationDto>>(result, Messages.SuccessApplicationListed);
        }
    }

    public IDataResult<List<GetListApplicationDto>> GetByOperationId(int operationId)
    {
        using (var context = new GulenyuzTedarikContext())
        {
            var query = context.Applications.Where(a => a.OperationId == operationId)
                .Join(context.Drivers,
                application => application.DriverId,
                driver => driver.Id,
                (application, Driver) => new GetListApplicationDto
                {
                    Id = application.Id,
                    DriverId = Driver.Id,
                    status = application.Status,
                    OperationId = application.OperationId,
                    FirstName = Driver.FirstName,
                    LastName = Driver.LastName,
                    Address = Driver.Address,
                    PhoneNumber = Driver.PhoneNumber,
                    Email = Driver.Email,
                    HasSrc = Driver.HasSrc,
                    CreatedDate = Driver.CreatedDate,
                    UpdatedDate = Driver.UpdatedDate,
                    DeletedDate = Driver.DeletedDate
                });
            List<GetListApplicationDto> result = query.ToList();
            return new SuccessDataResult<List<GetListApplicationDto>>(result, Messages.SuccessApplicationListed);
        }
    }

    public IDataResult<List<GetListApplicationDto>> GetListByStatus(int status)
    {
        using (var context = new GulenyuzTedarikContext())
        {
            var query = context.Applications.Where(a => a.Status == status)
                .Join(context.Drivers,
                application => application.DriverId,
                driver => driver.Id,
                (application, Driver) => new GetListApplicationDto
                {
                    Id = application.Id,
                    DriverId = Driver.Id,
                    status = application.Status,
                    OperationId = application.OperationId,
                    FirstName = Driver.FirstName,
                    LastName = Driver.LastName,
                    Address = Driver.Address,
                    PhoneNumber = Driver.PhoneNumber,
                    Email = Driver.Email,
                    HasSrc = Driver.HasSrc,
                    CreatedDate = Driver.CreatedDate,
                    UpdatedDate = Driver.UpdatedDate,
                    DeletedDate = Driver.DeletedDate
                });
            List<GetListApplicationDto> result = query.ToList();
            return new SuccessDataResult<List<GetListApplicationDto>>(result, Messages.SuccessApplicationListed);
        }
    }

    public IDataResult<List<GetListApplicationDto>> GetList()
    {
        using (var context = new GulenyuzTedarikContext())
        {
            var query = context.Applications
                .Join(context.Drivers,
                application => application.DriverId,
                driver => driver.Id,
                (application, Driver) => new GetListApplicationDto
                {
                    Id = application.Id,
                    DriverId = Driver.Id,
                    status = application.Status,
                    OperationId = application.OperationId,
                    FirstName = Driver.FirstName,
                    LastName = Driver.LastName,
                    Address = Driver.Address,
                    PhoneNumber = Driver.PhoneNumber,
                    Email = Driver.Email,
                    HasSrc = Driver.HasSrc,
                    CreatedDate = Driver.CreatedDate,
                    UpdatedDate = Driver.UpdatedDate,
                    DeletedDate = Driver.DeletedDate
                });
            List<GetListApplicationDto> result = query.ToList();
            return new SuccessDataResult<List<GetListApplicationDto>>(result, Messages.SuccessApplicationListed);
        }
    }

    public IResult Update(UpdateApplicationDto updateApplicationDto)
    {
       Application application = _applicationDal.Get(a => a.Id == updateApplicationDto.Id);
        application.DriverId = updateApplicationDto.DriverId;
        application.OperationId = updateApplicationDto.OperationId;
        application.Status = updateApplicationDto.Status;
        this.OnApplicationUpdated(application);
        _applicationDal.Update(application);
        return new SuccessResult(Messages.SuccessApplicationUpdated);
    }

    private void OnApplicationAdded(Application application)
    {
        application.CreatedDate = DateTime.Now;
    }
    private void OnApplicationDeleted(Application application)
    {
        application.DeletedDate = DateTime.Now;
    }
    private void OnApplicationUpdated(Application application)
    {
        application.UpdatedDate = DateTime.Now;
    }
}
