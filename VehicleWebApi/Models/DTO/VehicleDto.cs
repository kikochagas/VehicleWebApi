using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleWebApi.Models.DTO
{
    public class VehicleDto
    {
        public Guid RequestId { get; set; }
        public string Vin { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public Guid ModelId { get; set; }

        public virtual ModelDto Model { get; set; }
    }
}
