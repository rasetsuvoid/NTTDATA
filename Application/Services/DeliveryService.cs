using Application.Common.Dtos.Delivery;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DeliveryService : GenericService<Delivery>, IDeliveryService
    {

        public DeliveryService(IDeliveryRepository repository) : base(repository)
        {
        }

        public async Task<DeliveryResponseDto> CalculateProvisionsAsync(DeliveryRequestDto request)
        {
            int provisionsToDeliver = await CalculateProvisionsCountAsync(request.UnitCount);
            TimeSpan estimatedDeliveryTime = await CalculateEstimatedDeliveryTimeAsync(request.CurrentTime, request.WeatherType);

            double originLongitude = 0.0;
            double originLatitude = 0.0;

            DateTime deliveryDateTime = request.CurrentDate.Add(request.CurrentTime).Add(estimatedDeliveryTime);

            DeliveryResponseDto result = new DeliveryResponseDto
            {
                OriginLongitude = originLongitude,
                OriginLatitude = originLatitude,
                DeliveryDate = deliveryDateTime.Date,
                DeliveryTime = deliveryDateTime.TimeOfDay,
                EstimatedTime = estimatedDeliveryTime,
                ProvisionsToDeliver = provisionsToDeliver
            };

            Delivery delivery = new Delivery();

            //await _repository.AddAsync(delivery);

            return result;
        }

        public async Task<int> CalculateProvisionsCountAsync(int unitCount)
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

        private int Fibonacci(int n)
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

        public async Task<TimeSpan> CalculateEstimatedDeliveryTimeAsync(TimeSpan time, string weather)
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


    }
}
