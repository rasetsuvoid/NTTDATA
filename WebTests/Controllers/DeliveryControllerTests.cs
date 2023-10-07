using Application.Common.Dtos.Delivery;
using Application.Common.Dtos.Generic;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web.Controllers;

namespace WebTests.Controllers
{
    [TestClass]
    public class DeliveryControllerTests
    {
        private Mock<IDeliveryService> _serviceMock;
        private DeliveryController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _serviceMock = new Mock<IDeliveryService>();
            _controller = new DeliveryController(_serviceMock.Object);
        }

        [TestMethod]
        public async Task CalculateProvisionsAsync_ShouldReturnStatusCodeFromService()
        {
            // Arrange
            DeliveryRequestDto request = new DeliveryRequestDto()
            {
                CurrentDate = DateTime.Now,
                CurrentTime = "12:30:00",
                DestinationLatitude = 2,
                DestinationLongitude = 2,
                UnitCount = 1,
                WeatherType = "lluvioso"
            };

            var response = new HttpResponse<DeliveryResponseDto>(HttpStatusCode.OK, "Resultado Exitoso", new DeliveryResponseDto());
            _serviceMock.Setup(s => s.CalculateProvisionsAsync(request)).ReturnsAsync(response);

            // Act
            var result = await _controller.CalculateProvisionsAsync(request);

            // Assert
            var statusCodeResult = (HttpStatusCode)result
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(result, null);
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(response.StatusCode, statusCodeResult);
        }
    }
}
