using Application.Common.Dtos.Coordinates;
using Application.Common.Dtos.Generic;
using Application.Common.Interfaces;
using Domain.Entities;
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
    public class CoordinatesControllerTests
    {
        private Mock<ICoordinatesService> _serviceMock;
        private CoordinatesController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _serviceMock = new Mock<ICoordinatesService>();
            _controller = new CoordinatesController(_serviceMock.Object);
        }

        [TestMethod]
        public async Task GetCoordinateById_ShouldReturnNotFound_WhenCoordinateDoesNotExist()
        {
            // Arrange
            int id = 1;
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((Coordinates)null);

            // Act
            IActionResult result = await _controller.GetCoordinateById(id);

            // Assert


            var statusCodeResult = (HttpStatusCode)result
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(result, null);

            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(HttpStatusCode.NotFound, statusCodeResult);
        }

        [TestMethod]
        public async Task CreateCoordinate_ShouldReturnStatusCodeFromService()
        {
            // Arrange
            var request = new CoordinatesRequestDto { Latitude = 10, Longitude = 2 };
            var response = new HttpResponse<string>(HttpStatusCode.OK, "Creado Exitosamente", string.Empty);
            _serviceMock.Setup(s => s.CreateCoordinates(request)).ReturnsAsync(response);

            // Act
            var result = await _controller.CreateCoordinate(request);

            // Assert
            var statusCodeResult = (HttpStatusCode)result
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(result, null);
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(response.StatusCode, statusCodeResult);
        }

        [TestMethod]
        public async Task GetCoordinateById_ShouldReturnOk_WhenCoordinateExists()
        {
            // Arrange
            int id = 1;
            var coordinates = new Coordinates { Latitude = 20, Longitude = 1 };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(coordinates);

            // Act
            var result = await _controller.GetCoordinateById(id);

            // Assert
            var statusCodeResult = (HttpStatusCode)result
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(result, null);
            Assert.IsNotNull(statusCodeResult); Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(HttpStatusCode.OK, statusCodeResult);
        }
    }
}
