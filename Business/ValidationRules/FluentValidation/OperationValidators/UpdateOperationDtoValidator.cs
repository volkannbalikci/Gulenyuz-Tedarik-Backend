using Entities.Dtos.OperationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.OperationValidators;

public class UpdateOperationDtoValidator : AbstractValidator<UpdateOperationDto>
{
	public UpdateOperationDtoValidator()
	{
		RuleFor(o => o.Id).NotEmpty();
		RuleFor(o => o.Name).NotEmpty();
		RuleFor(o => o.Text).NotEmpty();
	}
}
