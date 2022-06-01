using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApi.Helpers;
using VehicleWebApi.Models.DTO;
using VehicleWebApi.Models.Tables;
using VehicleWebApi.Services;

namespace VehicleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;
        public VehicleController(IVehicleService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetAllAsync()
        {
            var list = (await _service.GetAllAsync())
                .Select(x => x.AsDto());
            return Ok(list);
        }
        [HttpGet(("{id}"))]
        public async Task<ActionResult<VehicleDto>> GetByIdAsync(Guid id)
        {
            var vehicle = await _service.GetAsync(id);
            if(vehicle == null)
                return NotFound();
            return Ok(vehicle.AsDto());
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(VehicleDto vehicle)
        {
            var _vehicle = new Vehicle
            {
                DeliveryDate = vehicle.DeliveryDate,
                ModelId = vehicle.ModelId,
                Vin = vehicle.Vin,
            };
            await _service.AddAsync(_vehicle);
            vehicle.RequestId = _vehicle.RequestId;
            return StatusCode(201, vehicle);

        }
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(VehicleDto vehicle)
        {
            Vehicle existingVehicle = await _service.GetAsync(vehicle.RequestId);
            if (existingVehicle == null)
                return NotFound();
            existingVehicle.DeliveryDate = vehicle.DeliveryDate;
            existingVehicle.ModelId = vehicle.ModelId;
            existingVehicle.Vin = vehicle.Vin;

            await _service.UpdateAsync(existingVehicle);

            return NoContent();
        }

        [HttpDelete(("{id}"))]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var existingVehicle = await _service.GetAsync(id);
            if (existingVehicle == null)
                return NotFound();
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
