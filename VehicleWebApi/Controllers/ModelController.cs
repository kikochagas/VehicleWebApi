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
    public class ModelController : ControllerBase
    {
        private readonly IModelService _service;
        public ModelController(IModelService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelDto>>> GetAllAsync()
        {
            var list = (await _service.GetAllAsync())
                .Select(x => x.AsDto());
            return Ok(list);
        }
        [HttpGet(("{id}"))]
        public async Task<ActionResult<ModelDto>> GetByIdAsync(Guid id)
        {
            var model = await _service.GetAsync(id);
            if(model == null)
                return NotFound();
            return Ok(model.AsDto());
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(ModelDto model)
        {
            var _model = new Model
            {
                Name = model.Name
            };
            await _service.AddAsync(_model);
            return StatusCode(201, _model);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ModelDto model)
        {
            Model existingModel = await _service.GetAsync(model.Id);
            if (existingModel == null)
                return NotFound();
            existingModel.Name = model.Name;

            await _service.UpdateAsync(existingModel);

            return NoContent();
        }

        [HttpDelete(("{id}"))]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var existingModel = await _service.GetAsync(id);
            if (existingModel == null)
                return NotFound();
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
