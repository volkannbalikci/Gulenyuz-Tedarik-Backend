using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.DriverDtos;

public class DeleteDriverDto : IDto
{
    public int Id { get; set; }
}
