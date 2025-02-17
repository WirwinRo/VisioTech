using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.api.Controllers;
using visiotech.application.Dtos;
using visiotech.application.Interfaces;
using visiotech.domain.Entities;

namespace TestVisioTech.Controllers
{
    public class VineyardsControllerTests
    {
        private readonly Mock<IManagerApp> _managerAppMock; // Mock del servicio
        private readonly ManagersController _controller; // Controlador a probar

        public VineyardsControllerTests()
        {
            // Inicializamos el mock
            _managerAppMock = new Mock<IManagerApp>();

            // Creamos el controlador pasando el mock como dependencia
            _controller = new ManagersController(_managerAppMock.Object);
        }
        [Fact]
        public async Task GetIds_ShouldReturnOkResult_WithData()
        {
            // Arrange
            var mockData = new List<ManagerDto>
        {
            new ManagerDto { ManagerID = 1, Name = "Alice" },
            new ManagerDto { ManagerID = 2, Name = "Bob" }
        };

            _managerAppMock.Setup(service => service.List()).ReturnsAsync(mockData);

            // Act
            var result = await _controller.GetIds();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<ManagerDto>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task GetManagersOrderbyName_ShouldReturnSortedData()
        {
            // Arrange
            var mockData = new List<ManagerDto>
        {
            new ManagerDto { ManagerID = 2, Name = "Zara" },
            new ManagerDto { ManagerID = 1, Name = "Alice" }
        };

            _managerAppMock.Setup(service => service.List()).ReturnsAsync(mockData);

            // Act
            var result = await _controller.GetManagersOrderbyName(true);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<ManagerDto>>(actionResult.Value);
            Assert.Equal("Alice", returnValue.First().Name);
        }


        [Fact]
        public async Task GetIds_ShouldReturnBadRequest_OnException()
        {
            // Arrange
            _managerAppMock.Setup(service => service.List()).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.GetIds();

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var errorMessage = actionResult.Value.GetType().GetProperty("message")?.GetValue(actionResult.Value, null);
            Assert.Contains("Database error", errorMessage as List<string>);
        }

    }
}
