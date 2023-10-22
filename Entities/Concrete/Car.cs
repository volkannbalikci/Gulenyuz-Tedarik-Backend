using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Car : EntityBase
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; } 
    public string EngineDisplacement { get; set; }
    public string Hp { get; set; }
    public ChasisType ChasisType { get; set; } 
    public bool HasFrigo { get; set; }

}
