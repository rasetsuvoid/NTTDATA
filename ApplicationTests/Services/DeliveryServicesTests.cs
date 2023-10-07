using Application.Common.Dtos.Delivery;
using Application.Common.Dtos.Generic;
using Application.Common.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests.Services
{
    [TestClass]
    public class DeliveryServicesTests
    {
        private Mock<IDeliveryRepository> _repositoryMock;
        private Mock<ICoordinatesRepository> _repositoryCoordinatesMock;
        private Mock<IRequestDeliveryRepository> _repositoryRquestMock;

        private DeliveryService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<IDeliveryRepository>();
            _repositoryCoordinatesMock = new Mock<ICoordinatesRepository>();
            _repositoryRquestMock = new Mock<IRequestDeliveryRepository>();
            _service = new DeliveryService(_repositoryMock.Object, _repositoryCoordinatesMock.Object, _repositoryRquestMock.Object);
        }

        [TestMethod] 
        public async Task CalculateProvisionsAsync_successResponse_WhenRequestIsValid()
        {
            DeliveryRequestDto deliveryRequestDto = new DeliveryRequestDto()
            {
                CurrentDate = DateTime.Now,
                CurrentTime = "12:30:00",
                DestinationLatitude = 2,
                DestinationLongitude = 2,
                UnitCount = 1,
                WeatherType = "lluvioso"
            };

            var expectedResponse = new HttpResponse<DeliveryResponseDto>(
                System.Net.HttpStatusCode.OK,
                "Resultado Exitoso",

                new DeliveryResponseDto()
                {
                    DeliveryDate = new DateTime(2023, 10, 7),
                    DeliveryTime = new TimeSpan(14, 30, 0),
                    EstimatedTime = new TimeSpan(2, 0, 0),
                    OriginLatitude = 10,
                    OriginLongitude = 11,
                    ProvisionsToDeliver = 1
                }
            );

            var coordinates = new Coordinates() { Latitude = 10, Longitude = 11 };

            _repositoryCoordinatesMock.Setup(x => x.GetCoordinates()).ReturnsAsync(coordinates);

            var result = await _service.CalculateProvisionsAsync(deliveryRequestDto);

            Assert.AreEqual(expectedResponse.StatusCode, result.StatusCode);
            Assert.AreEqual(expectedResponse.Message, result.Message);
        }

        [TestMethod]
        public async Task CalculateProvisionsAsync_successResponse_WhenRequestIsInValid()
        {
            DeliveryRequestDto deliveryRequestDto = new DeliveryRequestDto()
            {
                CurrentDate = DateTime.Now,
                CurrentTime = "12:30:00",
                DestinationLatitude = 2,
                DestinationLongitude = 2,
                UnitCount = 1,
                WeatherType = "noexiste"
            };

            var expectedResponse = new HttpResponse<DeliveryResponseDto>(
                System.Net.HttpStatusCode.BadRequest,
                "Propiedad: WeatherType, Error: El tipo de clima debe ser 'soleado' o 'lluvioso'.",
                new DeliveryResponseDto()
            );

            var result = await _service.CalculateProvisionsAsync(deliveryRequestDto);

            Assert.AreEqual(expectedResponse.StatusCode, result.StatusCode);
            Assert.AreEqual(expectedResponse.Message, result.Message);
        }

        [TestMethod]
        public async Task CalculateProvisionsCountAsync_IsUnitCount9()
        {
            int unitCount = 9;

            int expectedResult = 34;

            var result = await _service.CalculateProvisionsCountAsync(unitCount);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public async Task CalculateProvisionsCountAsync_IsUnitCount30()
        {
            int unitCount = 30;

            int expectedResult = 30;

            var result = await _service.CalculateProvisionsCountAsync(unitCount);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public async Task CalculateProvisionsCountAsync_IsUnitCount32()
        {
            int unitCount = 32;

            int expectedResult = 34;

            var result = await _service.CalculateProvisionsCountAsync(unitCount);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public async Task FibonacciN_1()
        {
            int n = 1;
            int expectedResult = 1;

            var result = _service.Fibonacci(n);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public async Task FibonacciN_4()
        {
            int n = 4;
            int expectedResult = 3;

            var result = _service.Fibonacci(n);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public async Task CalculateProvisionsAsync_ShouldHandleException()
        {
            // Arrange
            _repositoryCoordinatesMock.Setup(repo => repo.GetCoordinates()).Throws(new Exception("Simulated error"));

            DeliveryRequestDto deliveryRequestDto = new DeliveryRequestDto()
            {
                CurrentDate = DateTime.Now,
                CurrentTime = "12:30:00",
                DestinationLatitude = 2,
                DestinationLongitude = 2,
                UnitCount = 1,
                WeatherType = "soleado"
            };

            // Act
            var result = await _service.CalculateProvisionsAsync(deliveryRequestDto);

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.AreEqual("Ocurrio un error: Simulated error", result.Message);
            Assert.IsNotNull(result.Content);
        }

        [TestMethod]
        public async Task CalculateProvisionsAsync_successResponse_CordinatesNotFound()
        {
            DeliveryRequestDto deliveryRequestDto = new DeliveryRequestDto()
            {
                CurrentDate = DateTime.Now,
                CurrentTime = "12:30:00",
                DestinationLatitude = 2,
                DestinationLongitude = 2,
                UnitCount = 1,
                WeatherType = "lluvioso"
            };

            var expectedResponse = new HttpResponse<DeliveryResponseDto>(
                System.Net.HttpStatusCode.NotFound,
                "No se encontraron coordenadas configuradas.",
                new DeliveryResponseDto()
            );

            Coordinates coordinates = null;

            _repositoryCoordinatesMock.Setup(x => x.GetCoordinates()).ReturnsAsync(coordinates);

            var result = await _service.CalculateProvisionsAsync(deliveryRequestDto);

            Assert.AreEqual(expectedResponse.StatusCode, result.StatusCode);
            Assert.AreEqual(expectedResponse.Message, result.Message);
        }
    }
}
