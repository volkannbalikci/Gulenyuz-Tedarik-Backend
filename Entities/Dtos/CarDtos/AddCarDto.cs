using Core.Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.CarDtos;

public class AddCarDto : IDto
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string EngineDisplacement { get; set; }
    public string Hp { get; set; }
    public bool HasFrigo { get; set; }
    public ChasisType ChasisType { get; set; }
}
