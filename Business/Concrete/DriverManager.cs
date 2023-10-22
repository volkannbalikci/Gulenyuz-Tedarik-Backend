using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.DriverValidators;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.DriverDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class DriverManager : IDriverService
{
    private readonly IDriverDal _driverDal;
    public DriverManager(IDriverDal driverDal)
    {
        _driverDal = driverDal;
    }

    [ValidationAspect(typeof(AddDriverDtoValidator))]
    public IResult Add(AddDriverDto addDriverDto)
    {
        Driver driver = new()
        {
            FirstName = addDriverDto.FirstName,
            LastName = addDriverDto.LastName,
            Email = addDriverDto.Email,
            PhoneNumber = addDriverDto.PhoneNumber,
            Address = addDriverDto.Address,
            HasSrc = addDriverDto.HasSrc,
        };
        this.OnDriverAdd(driver);
        _driverDal.Add(driver);
        return new SuccessResult(Messages.SuccessDriverAdded);
    }

    public IResult Delete(DeleteDriverDto deleteDriverDto)
    {
        Driver driver = new()
        {
            Id = deleteDriverDto.Id
        };
        OnDriverDelete(driver);
        _driverDal.Delete(driver);
        return new SuccessResult(Messages.SuccessDriverDeleted);
    }

    public IDataResult<List<Driver>> GetByEmail(string email)
    {
        return new SuccessDataResult<List<Driver>>(_driverDal.GetList(d => d.Email == email), Messages.SuccessDriversListed);
    }

    public IDataResult<Driver> GetById(int id)
    {
        return new SuccessDataResult<Driver>(_driverDal.Get(d => d.Id == id), Messages.SuccessDriverListed);
    }

    public IDataResult<List<Driver>> GetByLastName(string lastName)
    {
        return new SuccessDataResult<List<Driver>>(_driverDal.GetList(d => d.LastName == lastName), Messages.SuccessDriversListed);
    }

    public IDataResult<Driver> GetByName(string name)
    {
        return new SuccessDataResult<Driver>(_driverDal.Get(d => d.FirstName == name), Messages.SuccessDriversListed);
    }

    public IDataResult<List<Driver>> GetByPhoneNumber(string phoneNumber)
    {
        return new SuccessDataResult<List<Driver>>(_driverDal.GetList(d => d.PhoneNumber == phoneNumber), Messages.SuccessDriversListed);
    }

    public IDataResult<List<Driver>> GetList()
    {
        return new SuccessDataResult<List<Driver>>(_driverDal.GetList(), Messages.SuccessDriversListed);
    }

    [ValidationAspect(typeof(UpdateDriverDtoValidator))]
    public IResult Update(UpdateDriverDto updateDriverDto)
    {
        Driver driver = _driverDal.Get(d => d.Id == updateDriverDto.Id);
        driver.FirstName = updateDriverDto.FirstName;
        driver.LastName = updateDriverDto.LastName;
        driver.Email = updateDriverDto.Email;
        driver.PhoneNumber = updateDriverDto.PhoneNumber;
        driver.Address = updateDriverDto.Address;
        driver.HasSrc = updateDriverDto.HasSrc;
        OnDriverUpdate(driver);
        _driverDal.Update(driver);
        return new SuccessResult(Messages.SuccessDriverUpdated);
    }

    private void OnDriverAdd(Driver driver)
    {
        driver.CreatedDate = DateTime.Now;
    }
    private void OnDriverUpdate(Driver driver)
    {
        driver.UpdatedDate = DateTime.Now;
    }
    private void OnDriverDelete(Driver driver)
    {
        driver.DeletedDate = DateTime.Now;
    }

    public IDataResult<List<Driver>> GetByHasSrc(bool hasSrc)
    {
        return new SuccessDataResult<List<Driver>>(_driverDal.GetList(d => d.HasSrc == hasSrc), Messages.SuccessDriverListed);
    }
}
