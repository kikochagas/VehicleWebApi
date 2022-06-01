using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleWebApi.Models.Tables
{
    public class Model
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
