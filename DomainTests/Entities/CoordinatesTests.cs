using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.Entities
{
    [TestClass]
    public class CoordinatesTests
    {
        [TestMethod]
        public void Coordinates_WithValidData_ShouldPass()
        {
            // Arrange
            var coordinates = new Coordinates
            {
                Longitude = 45.6789M,
                Latitude = -23.4567M
            };

            // Assert
            Assert.AreEqual(45.6789M, coordinates.Longitude);
            Assert.AreEqual(-23.4567M, coordinates.Latitude);
        }
    }
}
