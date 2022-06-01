using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleWebApi.Models.DTO
{
    public class ModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
