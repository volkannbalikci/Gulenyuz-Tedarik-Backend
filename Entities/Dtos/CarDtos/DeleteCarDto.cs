using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.CarDtos;

public class DeleteCarDto : IDto
{
    public int Id { get; set; }
}
