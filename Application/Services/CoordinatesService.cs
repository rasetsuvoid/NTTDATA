using Application.Common.Dtos.Coordinates;
using Application.Common.Dtos.Delivery;
using Application.Common.Dtos.Generic;
using Application.Common.Interfaces;
using Application.Common.Validations;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CoordinatesService : GenericService<Coordinates>, ICoordinatesService
    {
        private readonly IMapper _mapper;

        public CoordinatesService(ICoordinatesRepository repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<HttpResponse<string>> CreateCoordinates(CoordinatesRequestDto request)
        {
            HttpResponse<string> response = new HttpResponse<string>(System.Net.HttpStatusCode.OK, "Coordenadas creadas exitosamente.", string.Empty);

            try
            {
                string validations = await Validations(request);

                if (!string.IsNullOrEmpty(validations))
                {
                    response.Message = validations;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    response.Content = string.Empty;
                    return response;
                }

                Coordinates coordinates = _mapper.Map<Coordinates>(request);
                coordinates.Active = true;
                await _repository.AddAsync(coordinates);

            }
            catch (Exception ex)
            {
                response.Message = $"Ocurrio un error: {ex.Message}";
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Content = string.Empty;
                return response;
            }

            return response;
        }

        private async Task<string> Validations(CoordinatesRequestDto request)
        {
            try
            {
                CoordinatesRequestDtoValidator validator = new CoordinatesRequestDtoValidator();
                FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    foreach (FluentValidation.Results.ValidationFailure? error in validationResult.Errors)
                    {
                        return $"Propiedad: {error.PropertyName}, Error: {error.ErrorMessage}";
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
