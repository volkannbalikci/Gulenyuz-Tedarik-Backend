﻿using Entities.Dtos.DriverDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.DriverValidators;

public class UpdateDriverDtoValidator : AbstractValidator<UpdateDriverDto>
{
	public UpdateDriverDtoValidator()
	{
		RuleFor(d => d.FirstName).NotEmpty();
		RuleFor(d => d.LastName).NotEmpty();
		RuleFor(d => d.Address).NotEmpty();
		RuleFor(d => d.Email).NotEmpty();
		RuleFor(d => d.PhoneNumber).NotEmpty();
		RuleFor(d => d.HasSrc).NotEmpty();
	}
}
