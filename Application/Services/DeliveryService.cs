using Application.Common.Dtos.Delivery;
using Application.Common.Dtos.Generic;
using Application.Common.Interfaces;
using Application.Common.Validations;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DeliveryService : GenericService<Delivery>, IDeliveryService
    {
        private readonly ICoordinatesRepository _coordinatesRepository;
        private readonly IRequestDeliveryRepository _requestDeliveryRepository;

        public DeliveryService(IDeliveryRepository repository, ICoordinatesRepository coordinatesRepository, IRequestDeliveryRepository requestDeliveryRepository) : base(repository)
        {
            _coordinatesRepository = coordinatesRepository;
            _requestDeliveryRepository = requestDeliveryRepository;
        }

        public async Task<HttpResponse<DeliveryResponseDto>> CalculateProvisionsAsync(DeliveryRequestDto request)
        {
            HttpResponse<DeliveryResponseDto> response = new HttpResponse<DeliveryResponseDto>(System.Net.HttpStatusCode.OK, "Resultado Exitoso", null);

            try
            {
                string validations = await Validations(request);

                if (!string.IsNullOrEmpty(validations))
                {
                    response.Message = validations;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    response.Content = new DeliveryResponseDto();
                    return response;
                }

                int provisionsToDeliver = await CalculateProvisionsCountAsync(request.UnitCount);
                TimeSpan estimatedDeliveryTime = await CalculateEstimatedDeliveryTimeAsync(TimeSpan.Parse(request.CurrentTime) , request.WeatherType);

                Coordinates coordinates = await _coordinatesRepository.GetCoordinates();

                if (object.Equals(coordinates, null))
                {
                    response.Message = "No se encontraron coordenadas configuradas.";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    response.Content = new DeliveryResponseDto();
                    return response;
                }

                DateTime deliveryDateTime = request.CurrentDate.Date.Add(TimeSpan.Parse(request.CurrentTime)).Add(estimatedDeliveryTime);

                response.Content = new DeliveryResponseDto
                {
                    OriginLongitude = (double)coordinates.Longitude,
                    OriginLatitude = (double)coordinates.Latitude,
                    DeliveryDate = deliveryDateTime.Date,
                    DeliveryTime = deliveryDateTime.TimeOfDay,
                    EstimatedTime = estimatedDeliveryTime,
                    ProvisionsToDeliver = provisionsToDeliver
                };

                await MapperDelivery(provisionsToDeliver, deliveryDateTime, request, estimatedDeliveryTime, coordinates.Id);

            }
            catch (Exception ex)
            {
                response.Message = $"Ocurrio un error: {ex.Message}";
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Content = new DeliveryResponseDto();
                return response;
            }


            return response;
        }

        public async Task<int> CalculateProvisionsCountAsync(int unitCount)
        {
            try
            {
                if (unitCount <= 10)
                {
                    return Fibonacci(unitCount);
                }
                else if (unitCount <= 30)
                {
                    return 30;
                }
                else
                {
                    return unitCount + 2;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private int Fibonacci(int n)
        {
            try
            {
                if (n <= 1)
                {
                    return n;
                }
                int a = 0;
                int b = 1;
                for (int i = 2; i <= n; i++)
                {
                    int temp = a;
                    a = b;
                    b = temp + b;
                }
                return b;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<TimeSpan> CalculateEstimatedDeliveryTimeAsync(TimeSpan time, string weather)
        {
            try
            {
                if (weather == "Soleado")
                {
                    if (time.Hours >= 6 && time.Hours < 12)
                    {
                        return TimeSpan.FromHours(new Random().Next(4, 6));
                    }
                    else if (time.Hours >= 12 && time.Hours < 18)
                    {
                        return TimeSpan.FromHours(new Random().Next(3, 5));
                    }
                }
                else if (weather == "Lluvioso")
                {
                    return TimeSpan.FromHours(new Random().Next(6, 8));
                }
                return TimeSpan.FromHours(new Random().Next(2, 3));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        private async Task MapperDelivery(int provisionsToDeliver, DateTime deliveryDateTime, DeliveryRequestDto request, TimeSpan estimatedDeliveryTime, int coordinatesId)
        {
            try
            {
                Delivery delivery = new Delivery()
                {
                    Active = true,
                    DeliveredQuantity = provisionsToDeliver,
                    DeliveryDate = deliveryDateTime.Date + deliveryDateTime.TimeOfDay,
                    DestinationLatitude = (decimal)request.DestinationLatitude,
                    DestinationLongitude = (decimal)request.DestinationLongitude,
                    EstimatedTime = estimatedDeliveryTime,
                    IsDeleted = false,
                    CoordinatesId = coordinatesId,
                };

                int deliveryId = await _repository.AddWithIdAsync(delivery);

                RequestDelivery requestDelivery = new RequestDelivery()
                {
                    DeliveryId = deliveryId,
                    CurrentDate = request.CurrentDate,
                    CurrentTime = TimeSpan.Parse(request.CurrentTime),
                    DestinationLatitude = (decimal)request.DestinationLatitude,
                    DestinationLongitude= (decimal)request.DestinationLongitude,
                    WeatherType = request.WeatherType,
                    Active = true,
                    unitCount = request.UnitCount,
                    IsDeleted = false
                };

                await _requestDeliveryRepository.AddAsync(requestDelivery);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async Task<string> Validations(DeliveryRequestDto request)
        {
            try
            {
                DeliveryRequestDtoValidator validator = new DeliveryRequestDtoValidator();
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
