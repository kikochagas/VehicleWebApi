using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApi.Controllers;
using VehicleWebApi.Helpers;
using VehicleWebApi.Models.DTO;
using VehicleWebApi.Models.Tables;
using VehicleWebApi.Services;
using Xunit;

namespace VehicleWebApi.Tests
{
    public class VehiclesTests
    {
        private readonly Mock<IVehicleService> _service = new();

        [Fact]
        public async Task GetByIdAsync_WithUnexistingVehicle_ReturnsNotFound()
        {
            //Arrange
            _service.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Vehicle)null);
            var controller = new VehicleController(_service.Object);
            //Act
            var result = await controller.GetByIdAsync(Guid.NewGuid());
            //Assert
            result.Result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public async Task GetByIdAsync_WithExistingVehicle_ReturnsVehicle()
        {
            //Arrange
            var expectedVehicle = CreateRandomVehicle();

            _service.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(expectedVehicle);
            var controller = new VehicleController(_service.Object);
            //Act
            var actionResult = await controller.GetByIdAsync(Guid.NewGuid());
            var result = actionResult.Result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();

            result.Value.Should().BeEquivalentTo(expectedVehicle,
                options => options.ComparingByMembers<Vehicle>());

        }

        [Fact]
        public async Task GetAllAsync_WithExistingVehicle_ReturnsAllVehicles()
        {
            //Arrange
            var expectedVehicles = new[] { CreateRandomVehicle(), CreateRandomVehicle(), CreateRandomVehicle() };

            _service.Setup(s => s.GetAllAsync())
            .ReturnsAsync(expectedVehicles);
            var controller = new VehicleController(_service.Object);
            //Act
            var actualVehicles = await controller.GetAllAsync();
            var result = actualVehicles.Result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();

            result.Value.Should().BeEquivalentTo(expectedVehicles,
                options => options.ComparingByMembers<Vehicle>());

        }

        [Fact]
        public async Task AddAsync_WithVehicleToCreate_ReturnsStatusCodeObjectWithVehicle()
        {
            //Arrange
            var newVehicle = CreateRandomVehicle().AsDto();
            newVehicle.Model = new ModelDto
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
            };
            var controller = new VehicleController(_service.Object);
            //Act
            var createdVehicle = await controller.AddAsync(newVehicle);
            var result = createdVehicle as ObjectResult;
            //Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(201);
            result.Value.Should().BeEquivalentTo(newVehicle,
                 options => options.ComparingByMembers<VehicleDto>().Excluding(x=> x.RequestId));

        }
        [Fact]
        public async Task UpdateAsync_WithExistingVehicle_ReturnsNoContent()
        {
            //Arrange
            var existingVehicle = CreateRandomVehicle();

            _service.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(existingVehicle);
            var vehicleToUpdate = new VehicleDto
            {
                RequestId = existingVehicle.RequestId,
                Vin = Guid.NewGuid().ToString(),
                DeliveryDate = existingVehicle.DeliveryDate.Value.AddHours(3)
            };
            var controller = new VehicleController(_service.Object);
            //Act
            var result = await controller.UpdateAsync(vehicleToUpdate);
            //Assert
            result.Should().BeOfType<NoContentResult>();

        }

        [Fact]
        public async Task UpdateAsync_WithUnexistingVehicle_ReturnsNotFound()
        {
            //Arrange
            var existingVehicle = CreateRandomVehicle();

            _service.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Vehicle)null);
            var vehicleToUpdate = new VehicleDto
            {
                RequestId = existingVehicle.RequestId,
                Vin = Guid.NewGuid().ToString(),
                DeliveryDate = existingVehicle.DeliveryDate.Value.AddHours(3)
            };
            var controller = new VehicleController(_service.Object);
            //Act
            var result = await controller.UpdateAsync(vehicleToUpdate);
            //Assert
            result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public async Task DeleteAsync_WithUnexistingVehicle_ReturnsNotFound()
        {
            //Arrange
            var existingVehicleToDelete = CreateRandomVehicle();

            _service.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Vehicle)null);
            var controller = new VehicleController(_service.Object);
            //Act
            var result = await controller.DeleteAsync(existingVehicleToDelete.RequestId);
            //Assert
            result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public async Task DeleteAsync_WithExistingVehicle_ReturnsNoContent()
        {
            //Arrange
            var existingVehicle = CreateRandomVehicle();

            _service.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(existingVehicle);
            
            var controller = new VehicleController(_service.Object);
            //Act
            var result = await controller.DeleteAsync(existingVehicle.RequestId);
            //Assert
            result.Should().BeOfType<NoContentResult>();

        }

        private Vehicle CreateRandomVehicle()
        {
            return new Vehicle { 
                RequestId = Guid.NewGuid(), 
                Vin = Guid.NewGuid().ToString(), 
                DeliveryDate = DateTime.UtcNow,
                ModelId = Guid.NewGuid()
            };
        }
    }
}
