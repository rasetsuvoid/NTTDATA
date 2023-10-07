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
    public class DeliveryTests
    {
        [TestMethod]
        public void Delivery_WithValidData_ShouldPass()
        {
            // Arrange
            var delivery = new Delivery
            {
                CoordinatesId = 1,
                DestinationLongitude = 45.6789M,
                DestinationLatitude = -23.4567M,
                DeliveryDate = DateTime.Now,
                EstimatedTime = TimeSpan.FromHours(2),
                DeliveredQuantity = 10
            };

            // Act 

            // Assert
            Assert.AreEqual(1, delivery.CoordinatesId);
            Assert.AreEqual(45.6789M, delivery.DestinationLongitude);
            Assert.AreEqual(-23.4567M, delivery.DestinationLatitude);
            
        }
    }
}
