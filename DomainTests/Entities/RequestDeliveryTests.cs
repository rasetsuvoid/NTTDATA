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
    public class RequestDeliveryTests
    {
        [TestMethod]
        public void RequestDelivery_WithValidData_ShouldPass()
        {
            // Arrange
            var requestDelivery = new RequestDelivery
            {
                DestinationLongitude = 45.6789M,
                DestinationLatitude = -23.4567M,
                CurrentDate = new DateTime(2023, 10, 7),
                CurrentTime = new TimeSpan(8,0,0),
                WeatherType = "Soleado",
                unitCount = 5,
                DeliveryId = 1
            };

            // Act - No es necesario hacer nada en este caso, ya que estamos creando una instancia de RequestDelivery.

            // Assert
            Assert.AreEqual(45.6789M, requestDelivery.DestinationLongitude);
            Assert.AreEqual(-23.4567M, requestDelivery.DestinationLatitude);
            Assert.AreEqual(new DateTime(2023, 10, 7), requestDelivery.CurrentDate);
            Assert.AreEqual(new TimeSpan(8, 0, 0), requestDelivery.CurrentTime);
            Assert.AreEqual("Soleado", requestDelivery.WeatherType);
            Assert.AreEqual(5, requestDelivery.unitCount);
            Assert.AreEqual(1, requestDelivery.DeliveryId);
            // Puedes agregar más aserciones para las propiedades restantes según tus necesidades.
        }
    }
}
