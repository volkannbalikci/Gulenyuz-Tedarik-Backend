using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.CarValidators;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.CarDtos;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }
    [ValidationAspect(typeof(AddCarDtoValidator))]
    public IResult Add(AddCarDto addCarDto)
    {
        Car car = new()
        {
            Year = addCarDto.Year,
            Model = addCarDto.Model,
            Hp = addCarDto.Hp,
            EngineDisplacement = addCarDto.EngineDisplacement,
            Brand = addCarDto.Brand,
            ChasisType = addCarDto.ChasisType,
            HasFrigo = addCarDto.HasFrigo,
        };
        this.OnCarCreated(car);
        _carDal.Add(car);
        return new SuccessResult(Messages.SuccessCarAdded);
    }

    public IResult Delete(DeleteCarDto deleteCarDto)
    {
        Car car = new()
        {
            Id = deleteCarDto.Id,
        };
        this.OnCarDeleted(car);
        _carDal.Delete(car);
        return new SuccessResult(Messages.SuccessCarDeleted);
    }

    public IDataResult<List<Car>> GetByBrand(string brand)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.Brand == brand), Messages.SuccessCarsListed);
    }

    public IDataResult<List<Car>> GetByCarType(ChasisType chasisType)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.ChasisType == chasisType), Messages.SuccessCarsListed);
    }

    public IDataResult<List<Car>> GetByEngineDisplacement(string engineDisplacement)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.EngineDisplacement == engineDisplacement), Messages.SuccessCarsListed);
    }

    public IDataResult<List<Car>> GetByHasFrigo(bool hasFrigo)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.HasFrigo == hasFrigo), Messages.SuccessCarsListed);
    }

    public IDataResult<List<Car>> GetByHp(string hp)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.Hp == hp), Messages.SuccessCarsListed);
    }

    public IDataResult<Car> GetById(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.SuccessCarListed);
    }

    public IDataResult<List<Car>> GetByModel(string model)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.Model == model), Messages.SuccessCarsListed);
    }

    public IDataResult<List<Car>> GetByYear(int year)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.Year == year), Messages.SuccessCarsListed);
    }

    public IDataResult<List<Car>> GetList()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetList(), Messages.SuccessCarsListed);
    }

    [ValidationAspect(typeof(UpdateCarDtoValidator))]
    public IResult Update(UpdateCarDto updateCarDto)
    {
        Car car = _carDal.Get(c => c.Id == updateCarDto.Id);
        car.EngineDisplacement = updateCarDto.EngineDisplacement;
        car.Brand = updateCarDto.Brand;
        car.Hp = updateCarDto.Hp;
        car.Model = updateCarDto.Model;
        car.Year = updateCarDto.Year;
        car.HasFrigo = updateCarDto.HasFrigo;
        car.ChasisType = updateCarDto.ChasisType;
        this.OnCarUpdated(car);
        _carDal.Update(car);
        return new SuccessResult(Messages.SuccessCarUpdated);
    }

    private void OnCarCreated(Car car)
    {
        car.CreatedDate = DateTime.Now;
    }
    private void OnCarDeleted(Car car)
    {
        car.DeletedDate = DateTime.Now;
    }
    private void OnCarUpdated(Car car)
    {
        car.UpdatedDate = DateTime.Now;
    }
}
