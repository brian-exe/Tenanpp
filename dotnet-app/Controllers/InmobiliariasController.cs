using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tenanpp.Repository;
using Tenanpp.Core;
using Tenanpp.Repository.Models;

namespace Tenanpp.Controllers
{
    [Route("api/inmobiliarias")]
    [ApiController]
    public class InmobiliariaController : ControllerBase
    {
        private readonly IInmobiliariaRepository _dataRepository;
 
        public InmobiliariaController(IInmobiliariaRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
 
        // GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Inmobiliaria> inmobiliarias = await _dataRepository.GetAll();
            return Ok(inmobiliarias);
        }
 
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            Inmobiliaria inmobiliaria = await _dataRepository.Get(id);
 
            if (inmobiliaria == null)
            {
                return NotFound("No se encontró Inmobiliaria");
            }
 
            return Ok(inmobiliaria);
        }
 
        // POST: api/Employee
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Inmobiliaria inmobiliaria)
        {
            if (inmobiliaria == null)
            {
                return BadRequest("No se enviaron datos");
            }
 
            await _dataRepository.Add(inmobiliaria);
            return CreatedAtRoute(
                  "Get", 
                  new { Id = inmobiliaria.InmobiliariaId },
                  inmobiliaria);
        }
 
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Inmobiliaria inmobiliaria)
        {
            if (inmobiliaria == null)
            {
                return BadRequest("No se enviaron datos");
            }
 
            Inmobiliaria inmobiliariaToUpdate = await _dataRepository.Get(id);
            if (inmobiliariaToUpdate == null)
            {
                return NotFound("No se pudo encontrar la inmobiliaria");
            }
 
            await _dataRepository.Update(inmobiliariaToUpdate, inmobiliaria);
            return NoContent();
        }
 
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Inmobiliaria inmobiliaria = await _dataRepository.Get(id);
            if (inmobiliaria == null)
            {
                return NotFound("No se pudo encontrar la inmobiliaria");
            }
 
            await _dataRepository.Delete(inmobiliaria);
            return NoContent();
        }
    }
}
