using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleWebApi.Models.Tables
{
    public class Vehicle
    {
        [Key]
        public Guid RequestId { get; set; }
        [Required]
        //vehicle identification number
        public string Vin { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        public Guid ModelId { get; set; }

        public virtual Model Model { get; set; }
    }
}
