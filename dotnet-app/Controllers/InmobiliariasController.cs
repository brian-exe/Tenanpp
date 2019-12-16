using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tenanpp.Models;
using Tenanpp.Models.Repository;
using Tenanpp.Models.DataManager;

namespace Tenanpp.Controllers
{
    [Route("api/inmobiliarias")]
    [ApiController]
    public class InmobiliariaController : ControllerBase
    {
        private readonly IDataRepository<Inmobiliaria> _dataRepository;
 
        public InmobiliariaController(IDataRepository<Inmobiliaria> dataRepository)
        {
            _dataRepository = dataRepository;
        }
 
        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Inmobiliaria> inmobiliarias = _dataRepository.GetAll();
            return Ok(inmobiliarias);
        }
 
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Inmobiliaria inmobiliaria = _dataRepository.Get(id);
 
            if (inmobiliaria == null)
            {
                return NotFound("No se encontró Inmobiliaria");
            }
 
            return Ok(inmobiliaria);
        }
 
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Inmobiliaria inmobiliaria)
        {
            if (inmobiliaria == null)
            {
                return BadRequest("No se enviaron datos");
            }
 
            _dataRepository.Add(inmobiliaria);
            return CreatedAtRoute(
                  "Get", 
                  new { Id = inmobiliaria.InmobiliariaId },
                  inmobiliaria);
        }
 
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Inmobiliaria inmobiliaria)
        {
            if (inmobiliaria == null)
            {
                return BadRequest("No se enviaron datos");
            }
 
            Inmobiliaria inmobiliariaToUpdate = _dataRepository.Get(id);
            if (inmobiliariaToUpdate == null)
            {
                return NotFound("No se pudo encontrar la inmobiliaria");
            }
 
            _dataRepository.Update(inmobiliariaToUpdate, inmobiliaria);
            return NoContent();
        }
 
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Inmobiliaria inmobiliaria = _dataRepository.Get(id);
            if (inmobiliaria == null)
            {
                return NotFound("No se pudo encontrar la inmobiliaria");
            }
 
            _dataRepository.Delete(inmobiliaria);
            return NoContent();
        }
    }
}
