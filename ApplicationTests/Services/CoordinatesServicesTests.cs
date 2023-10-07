using Application.Common.Dtos.Coordinates;
using Application.Common.Validations;
using Application.Services;
using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationTests.Services
{
    [TestClass]
    public class CoordinatesServicesTests
    {
        private Mock<ICoordinatesRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private CoordinatesService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<ICoordinatesRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new CoordinatesService(_repositoryMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task CreateCoordinates_ShouldReturnSuccessResponse_WhenRequestIsValid()
        {
            // Arrange
            var request = new CoordinatesRequestDto { Latitude = 10.11, Longitude = -75.1652 };
            var coordinates = new Coordinates { Id = 1, Latitude = 10.11m, Longitude = -75.1652m,Active = true,CreatedDate = DateTime.Now, IsDeleted = false, UpdateDate = null };
            _mapperMock.Setup(m => m.Map<Coordinates>(request)).Returns(coordinates);

            // Act
            var response = await _service.CreateCoordinates(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Coordenadas creadas exitosamente.", response.Message);
        }

        [TestMethod]
        public async Task CreateCoordinates_ShouldReturnBadRequestResponse_WhenRequestIsInvalid()
        {
            // Arrange
            var request = new CoordinatesRequestDto { Latitude = 0, Longitude = 0 };          

            // Act
            var response = await _service.CreateCoordinates(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [TestMethod]
        public async Task CreateCoordinates_ShouldCatchException()
        {
            // Arrange
            var request = new CoordinatesRequestDto() { Longitude = 1, Latitude = 2}; 

            _mapperMock.Setup(m => m.Map<Coordinates>(request)).Throws(new Exception("Simulated mapping error"));

            // Mock del objeto _repository
            var repositoryMock = new Mock<IRepository<Coordinates>>(); 

            try
            {
                // Act
                var result = await _service.CreateCoordinates(request);

                // Assert

                Assert.AreEqual("Ocurrio un error: Simulated mapping error", result.Message);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Simulated mapping error", ex.Message);
            }
        }

        [TestMethod]
        public async Task ValidationsOK()
        {
            var request = new CoordinatesRequestDto() { Longitude = 1, Latitude = 2 };

            var result = _service.Validations(request);

            Assert.AreEqual("", result.Result);
        }

        [TestMethod]
        public async Task ValidationsError()
        {
            var request = new CoordinatesRequestDto() { Longitude = 1, Latitude = 0 };

            var result = _service.Validations(request);

            Assert.AreEqual("Propiedad: Latitude, Error: La Latitud es obligatoria.", result.Result);
        }

    }
}
