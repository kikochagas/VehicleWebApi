using Microsoft.EntityFrameworkCore;
using System;
using VehicleWebApi.Models.DTO;
using VehicleWebApi.Models.Tables;

namespace VehicleWebApi.Helpers
{
    public static class Extensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();
            modelBuilder.Entity<Model>().HasData(
                new Model { Id = guid1, Name = "Alfa Romeo 4C" },
                new Model { Id = guid2, Name = "Alfa Romeo Stelvio" },
                new Model { Id = guid3, Name = "Peugeot 2008 Allure 1.2" }
            );
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { RequestId = Guid.NewGuid(), Vin = "VN56RFF5656R6F", ModelId = guid1, DeliveryDate = DateTime.UtcNow },
                new Vehicle { RequestId = Guid.NewGuid(), Vin = "VN677BBB6B6BB", ModelId = guid3, DeliveryDate = DateTime.UtcNow },
                new Vehicle { RequestId = Guid.NewGuid(), Vin = "VN677HHTUY6BB", ModelId = guid2, DeliveryDate = DateTime.UtcNow }
            );
        }

        public static VehicleDto AsDto(this Vehicle vehicle)
        {
            VehicleDto dto = new VehicleDto();
            dto.RequestId = vehicle.RequestId;
            dto.Vin = vehicle.Vin;
            dto.ModelId = vehicle.ModelId;
            dto.DeliveryDate = vehicle.DeliveryDate;
            if(vehicle.Model != null)
            {
                dto.Model = new ModelDto();
                dto.Model.Id = vehicle.Model.Id;
                dto.Model.Name = vehicle.Model.Name;
            }
            return dto;
        }
        public static ModelDto AsDto(this Model model)
        {
            ModelDto dto = new ModelDto();
            dto.Id = model.Id;
            dto.Name = model.Name;
            return dto;
        }
    }
}
