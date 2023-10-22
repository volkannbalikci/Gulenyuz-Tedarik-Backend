using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ApplicationCarDtos;

public class AddApplicationCarDto : IDto
{
    public int DriverId { get; set; }
    public int CarId { get; set; }
    public int OperationId { get; set; }
    public int Status { get; set; }
}
