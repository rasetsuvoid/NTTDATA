using Application.Common.Dtos.Coordinates;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validations
{
    public class CoordinatesRequestDtoValidator : AbstractValidator<CoordinatesRequestDto>
    {
        public CoordinatesRequestDtoValidator()
        {
            RuleFor(dto => dto.Longitude)
                .InclusiveBetween(-180, 180)
                .WithMessage("La longitud debe estar entre -180 y 180 grados.");

            RuleFor(dto => dto.Latitude)
                .InclusiveBetween(-90, 90)
                .WithMessage("La latitud debe estar entre -90 y 90 grados.");

            RuleFor(dto => dto.Latitude)
                .NotEmpty()
                .WithMessage("La Latitud es obligatoria.");

            RuleFor(dto => dto.Longitude)
                .NotEmpty()
                .WithMessage("La Longitud es obligatoria.");
        }
    }
}
