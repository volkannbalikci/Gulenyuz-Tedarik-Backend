using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.CarDtos;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICarService
{
    IResult Add(AddCarDto addCarDto);
    IResult Update(UpdateCarDto updateCarDto);
    IResult Delete(DeleteCarDto deleteCarDto);
    IDataResult<List<Car>> GetList();
    IDataResult<Car> GetById(int id);
    IDataResult<List<Car>> GetByBrand(string brand);
    IDataResult<List<Car>> GetByModel(string model);
    IDataResult<List<Car>> GetByEngineDisplacement(string engineDisplacement);
    IDataResult<List<Car>> GetByYear(int year);
    IDataResult<List<Car>> GetByHp(string hp);
    IDataResult<List<Car>> GetByHasFrigo(bool hasFrigo);
    IDataResult<List<Car>> GetByCarType(ChasisType chasisType);
}
