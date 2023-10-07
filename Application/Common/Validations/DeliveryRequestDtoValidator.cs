using Application.Common.Dtos.Delivery;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validations
{
    public class DeliveryRequestDtoValidator : AbstractValidator<DeliveryRequestDto>
    {
        public DeliveryRequestDtoValidator()
        {
            RuleFor(dto => dto.DestinationLongitude)
                .InclusiveBetween(-180, 180)
                .WithMessage("La longitud debe estar entre -180 y 180 grados.");

            RuleFor(dto => dto.DestinationLatitude)
                .InclusiveBetween(-90, 90)
                .WithMessage("La latitud debe estar entre -90 y 90 grados.");

            RuleFor(dto => dto.DestinationLatitude)
                .NotEmpty()
                .WithMessage("La Latitud es obligatoria.");

            RuleFor(dto => dto.DestinationLongitude)
                .NotEmpty()
                .WithMessage("La Longitud es obligatoria.");

            RuleFor(dto => dto.CurrentDate)
                .NotEmpty()
                .WithMessage("La fecha actual es obligatoria.");

            RuleFor(dto => dto.CurrentTime)
                .NotEmpty()
                .WithMessage("La hora actual es obligatoria.");

            RuleFor(dto => dto.CurrentTime)
                .NotEmpty()
                .WithMessage("La hora actual es obligatoria.")
                .Must(time => TimeSpan.TryParse(time.ToString(), out _))
                .WithMessage("El formato de la hora actual no es válido.");

            RuleFor(dto => dto.WeatherType)
                .NotEmpty()
                .WithMessage("El tipo de clima es obligatorio.");

            RuleFor(dto => dto.WeatherType)
                .Must(weather => weather.ToLower() == "soleado" || weather.ToLower() == "lluvioso")
                .WithMessage("El tipo de clima debe ser 'soleado' o 'lluvioso'.");

            RuleFor(dto => dto.UnitCount)
                .GreaterThan(0)
                .WithMessage("La cantidad de unidades debe ser mayor que cero.");
        }
    }
}
