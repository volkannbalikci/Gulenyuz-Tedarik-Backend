using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class ApplicationBase : EntityBase
{
    public int Id { get; set; }
    public int DriverId { get; set; }
    public int OperationId { get; set; }
    public int Status { get; set; }
}
