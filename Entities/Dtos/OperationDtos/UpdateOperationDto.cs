using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.OperationDtos;

public class UpdateOperationDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
}
