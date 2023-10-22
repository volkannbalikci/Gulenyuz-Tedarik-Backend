using Entities.Dtos.CarDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.CarValidators;

public class AddCarDtoValidator : AbstractValidator<AddCarDto>
{
	public AddCarDtoValidator()
	{
		RuleFor(c => c.Brand).NotEmpty();
		RuleFor(c => c.Model).NotEmpty();
		RuleFor(c => c.Year).NotEmpty();
		RuleFor(c => c.Hp).NotEmpty();
		RuleFor(c => c.EngineDisplacement).NotEmpty();
	}
}
