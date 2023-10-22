using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos.ApplicationCarDtos;
using Entities.Dtos.ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ApplicationCarManager : IApplicationCarService
{
    private readonly IApplicationCarDal _applicationCarDal;
    public ApplicationCarManager(IApplicationCarDal applicationCarDal)
    {
        _applicationCarDal = applicationCarDal;
    }

    public IResult SubmitWithCar(AddApplicationCarDto addApplicationCarDto)
    {
        ApplicationCar applicationCar = new()
        {
            DriverId = addApplicationCarDto.DriverId,
            OperationId = addApplicationCarDto.OperationId,
            Status = addApplicationCarDto.Status,
            CarId = addApplicationCarDto.CarId,
        };
        this.OnApplicationCarAdded(applicationCar);
        _applicationCarDal.Add(applicationCar);
        return new SuccessResult(Messages.SuccessApplicationCarAdded);
    }

    public IResult Delete(DeleteApplicationCarDto deleteApplicationCarDto)
    {
        ApplicationCar applicationCar = new()
        {
            Id = deleteApplicationCarDto.Id
        };
        OnApplicationCarDeleted(applicationCar);
        _applicationCarDal.Delete(applicationCar);
        return new SuccessResult(Messages.SuccessApplicationCarDeleted);
    }

    public IResult Update(UpdateApplicationCarDto updateApplicationCarDto)
    {
        ApplicationCar applicationCar = _applicationCarDal.Get(ac => ac.Id == updateApplicationCarDto.Id);
        applicationCar.CarId = updateApplicationCarDto.CarId;
        applicationCar.DriverId = updateApplicationCarDto.DriverId;
        applicationCar.Status = updateApplicationCarDto.Status;
        applicationCar.OperationId = updateApplicationCarDto.OperationId;
        _applicationCarDal.Update(applicationCar);
        return new SuccessResult(Messages.SuccessApplicationCarUpdated);
    }

    public IDataResult<List<GetListApplicationCarDto>> GetList()
    {
        using (var context = new GulenyuzTedarikContext())
        {
            var query = context.ApplicationCars.Join(context.Drivers,
                applicationCar => applicationCar.DriverId,
                driver => driver.Id,
                (applicationCar, driver) => new
                {
                    driver.FirstName,
                    driver.LastName,
                    driver.Address,
                    driver.PhoneNumber,
                    driver.Email,
                    driver.HasSrc,
                    applicationCar.CreatedDate,
                    applicationCar.UpdatedDate,
                    applicationCar.DeletedDate,
                    applicationCar.CarId,
                    applicationCar.Id,
                    applicationCar.OperationId

                }).Join(context.Cars,
                _applicationCar => _applicationCar.CarId,
                car => car.Id,
                (_applicationCar, car) => new GetListApplicationCarDto
                {
                    Id = _applicationCar.Id,
                    CarId = car.Id,
                    OperationId = _applicationCar.OperationId,
                    FirstName = _applicationCar.FirstName,
                    LastName = _applicationCar.LastName,
                    Address = _applicationCar.Address,
                    PhoneNumber = _applicationCar.PhoneNumber,
                    Email = _applicationCar.Email,
                    HasSrc = _applicationCar.HasSrc,
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year,
                    EngineDisplacement = car.EngineDisplacement,
                    Hp = car.Hp,
                    ChasisType = car.ChasisType,
                    HasFrigo = car.HasFrigo,
                    CreatedDate = _applicationCar.CreatedDate,
                    UpdatedDate = _applicationCar.UpdatedDate,
                    DeletedDate = _applicationCar.DeletedDate,
                });
            List<GetListApplicationCarDto> result = query.ToList();
            return new SuccessDataResult<List<GetListApplicationCarDto>>(result, Messages.SuccessApplicationCarListed);
        }
    }

    public IDataResult<List<GetListApplicationCarDto>> GetById(int id)
    {
        using (var context = new GulenyuzTedarikContext())
        {
            var query = context.ApplicationCars.Where(ac => ac.Id == id).Join(context.Drivers,
                applicationCar => applicationCar.DriverId,
                driver => driver.Id,
                (applicationCar, driver) => new
                {
                    driver.FirstName,
                    driver.LastName,
                    driver.Address,
                    driver.PhoneNumber,
                    driver.Email,
                    driver.HasSrc,
                    applicationCar.CreatedDate,
                    applicationCar.UpdatedDate,
                    applicationCar.DeletedDate,
                    applicationCar.CarId,
                    applicationCar.Id,
                    applicationCar.OperationId

                }).Join(context.Cars,
                _applicationCar => _applicationCar.CarId,
                car => car.Id,
                (_applicationCar, car) => new GetListApplicationCarDto
                {
                    Id = _applicationCar.Id,
                    CarId = car.Id,
                    OperationId = _applicationCar.OperationId,
                    FirstName = _applicationCar.FirstName,
                    LastName = _applicationCar.LastName,
                    Address = _applicationCar.Address,
                    PhoneNumber = _applicationCar.PhoneNumber,
                    Email = _applicationCar.Email,
                    HasSrc = _applicationCar.HasSrc,
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year,
                    EngineDisplacement = car.EngineDisplacement,
                    Hp = car.Hp,
                    ChasisType = car.ChasisType,
                    HasFrigo = car.HasFrigo,
                    CreatedDate = _applicationCar.CreatedDate,
                    UpdatedDate = _applicationCar.UpdatedDate,
                    DeletedDate = _applicationCar.DeletedDate,
                });
            List<GetListApplicationCarDto> result = query.ToList();
            return new SuccessDataResult<List<GetListApplicationCarDto>>(result, Messages.SuccessApplicationCarListed);
        }
    }

    public IDataResult<List<GetListApplicationCarDto>> GetByCarId(int carId)
    {
        using (var context = new GulenyuzTedarikContext())
        {
            var query = context.ApplicationCars.Where(ac => ac.CarId == carId).Join(context.Drivers,
                applicationCar => applicationCar.DriverId,
                driver => driver.Id,
                (applicationCar, driver) => new
                {
                    driver.FirstName,
                    driver.LastName,
                    driver.Address,
                    driver.PhoneNumber,
                    driver.Email,
                    driver.HasSrc,
                    applicationCar.CreatedDate,
                    applicationCar.UpdatedDate,
                    applicationCar.DeletedDate,
                    applicationCar.CarId,
                    applicationCar.Id,
                    applicationCar.OperationId

                }).Join(context.Cars,
                _applicationCar => _applicationCar.CarId,
                car => car.Id,
                (_applicationCar, car) => new GetListApplicationCarDto
                {
                    Id = _applicationCar.Id,
                    OperationId = _applicationCar.OperationId,
                    FirstName = _applicationCar.FirstName,
                    LastName = _applicationCar.LastName,
                    Address = _applicationCar.Address,
                    PhoneNumber = _applicationCar.PhoneNumber,
                    Email = _applicationCar.Email,
                    HasSrc = _applicationCar.HasSrc,
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year,
                    EngineDisplacement = car.EngineDisplacement,
                    Hp = car.Hp,
                    ChasisType = car.ChasisType,
                    HasFrigo = car.HasFrigo,
                    CreatedDate = _applicationCar.CreatedDate,
                    UpdatedDate = _applicationCar.UpdatedDate,
                    DeletedDate = _applicationCar.DeletedDate,
                });
            List<GetListApplicationCarDto> result = query.ToList();
            return new SuccessDataResult<List<GetListApplicationCarDto>>(result, Messages.SuccessApplicationCarListed);
        }
    }

    public IDataResult<List<GetListApplicationCarDto>> GetByOperationId(int operationId)
    {
        using (var context = new GulenyuzTedarikContext())
        {
            var query = context.ApplicationCars.Where(ac => ac.OperationId == operationId).Join(context.Drivers,
                applicationCar => applicationCar.DriverId,
                driver => driver.Id,
                (applicationCar, driver) => new
                {
                    driver.FirstName,
                    driver.LastName,
                    driver.Address,
                    driver.PhoneNumber,
                    driver.Email,
                    driver.HasSrc,
                    applicationCar.CreatedDate,
                    applicationCar.UpdatedDate,
                    applicationCar.DeletedDate,
                    applicationCar.CarId,
                    applicationCar.Id,
                    applicationCar.OperationId

                }).Join(context.Cars,
                _applicationCar => _applicationCar.CarId,
                car => car.Id,
                (_applicationCar, car) => new GetListApplicationCarDto
                {
                    Id = _applicationCar.Id,
                    CarId = car.Id,
                    OperationId = _applicationCar.OperationId,
                    FirstName = _applicationCar.FirstName,
                    LastName = _applicationCar.LastName,
                    Address = _applicationCar.Address,
                    PhoneNumber = _applicationCar.PhoneNumber,
                    Email = _applicationCar.Email,
                    HasSrc = _applicationCar.HasSrc,
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year,
                    EngineDisplacement = car.EngineDisplacement,
                    Hp = car.Hp,
                    ChasisType = car.ChasisType,
                    HasFrigo = car.HasFrigo,
                    CreatedDate = _applicationCar.CreatedDate,
                    UpdatedDate = _applicationCar.UpdatedDate,
                    DeletedDate = _applicationCar.DeletedDate,
                });
            List<GetListApplicationCarDto> result = query.ToList();
            return new SuccessDataResult<List<GetListApplicationCarDto>>(result, Messages.SuccessApplicationCarListed);
        }
    }

    public void OnApplicationCarAdded(ApplicationCar applicationCar)
    {
        applicationCar.CreatedDate = DateTime.Now;
    }
    public void OnApplicationCarDeleted(ApplicationCar applicationCar)
    {
        applicationCar.DeletedDate = DateTime.Now;
    }
    public void OnApplicationCarUpdated(ApplicationCar applicationCar)
    {
        applicationCar.UpdatedDate = DateTime.Now;
    }
}



