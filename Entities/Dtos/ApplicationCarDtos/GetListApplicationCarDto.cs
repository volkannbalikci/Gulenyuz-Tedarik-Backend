using Core.Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ApplicationCarDtos;

public class GetListApplicationCarDto : IDto
{
    //drive
    public int Id { get; set; }
    public int OperationId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public bool HasSrc { get; set; }
    //car
    public int CarId { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string EngineDisplacement { get; set; }
    public string Hp { get; set; }
    public ChasisType ChasisType { get; set; }
    public bool HasFrigo { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
