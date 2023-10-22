using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.DriverDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IDriverService
{
    IResult Add(AddDriverDto addDriverDto);
    IResult Update(UpdateDriverDto updateDriverDto);
    IResult Delete(DeleteDriverDto deleteDriverDto);
    IDataResult<List<Driver>> GetList();
    IDataResult<Driver> GetById(int id);
    IDataResult<Driver> GetByName(string name);
    IDataResult<List<Driver>> GetByLastName(string lastName);
    IDataResult<List<Driver>> GetByEmail(string email);
    IDataResult<List<Driver>> GetByPhoneNumber(string phoneNumber);
    IDataResult<List<Driver>> GetByHasSrc(bool hasSrc);

}
