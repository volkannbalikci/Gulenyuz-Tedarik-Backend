using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ApplicationDtos;

public class UpdateApplicationDto : IDto
{
    public int Id { get; set; }
    public int DriverId { get; set; }
    public int OperationId { get; set; }
    public int Status { get; set; }
}
