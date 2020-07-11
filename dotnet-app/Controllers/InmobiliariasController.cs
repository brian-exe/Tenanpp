using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tenanpp.Core.Service;
using Tenanpp.DAL.Models;
using Tenanpp.ApiResponses;
namespace Tenanpp.Controllers
{
    [Route("api/inmobiliarias")]
    [ApiController]
    public class InmobiliariaController : Controller
    {
        private readonly IInmobiliariaService<Inmobiliaria> _service;
 
        public InmobiliariaController(IInmobiliariaService<Inmobiliaria> service)
        {
            _service = service;
        }
 
        // GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Inmobiliaria> inmobiliarias = await _service.GetAll();
            return Ok( new OkApiResponse(inmobiliarias));
        }
 
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            Inmobiliaria inmobiliaria = await _service.GetById(id);
 
            if (inmobiliaria == null)
            {
                return NotFound( new NotFoundApiResponse("No se encontró Inmobiliaria"));
            }
 
            return Ok(new OkApiResponse(inmobiliaria));
        }

        [Route("/image/{id}")]
        [HttpGet]
        public async Task<IActionResult> getProductImage(int id)
        {
            FotoPerfil foto = await _service.GetFoto(id);
            if (foto == null)
            {
                return NotFound( new NotFoundApiResponse("No se encontró foto"));
            }
            //return Ok(new OkApiResponse(inmobiliaria));
            return File(foto.Data, "image/png", "");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing && _service != null)
                _service.Dispose();
            base.Dispose(disposing);
        }
 
        // // POST: api/Employee
        // [HttpPost]
        // public async Task<IActionResult> Post([FromBody] Inmobiliaria inmobiliaria)
        // {
        //     if (inmobiliaria == null)
        //     {
        //         return BadRequest("No se enviaron datos");
        //     }
 
        //     await _service.Add(inmobiliaria);
        //     return CreatedAtRoute(
        //           "Get", 
        //           new { Id = inmobiliaria.InmobiliariaId },
        //           inmobiliaria);
        // }
 
        // // PUT: api/Employee/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(long id, [FromBody] Inmobiliaria inmobiliaria)
        // {
        //     if (inmobiliaria == null)
        //     {
        //         return BadRequest("No se enviaron datos");
        //     }
 
        //     Inmobiliaria inmobiliariaToUpdate = await _service.Get(id);
        //     if (inmobiliariaToUpdate == null)
        //     {
        //         return NotFound("No se pudo encontrar la inmobiliaria");
        //     }
 
        //     await _service.Update(inmobiliariaToUpdate, inmobiliaria);
        //     return NoContent();
        // }
 
        // // DELETE: api/Employee/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(long id)
        // {
        //     Inmobiliaria inmobiliaria = await _service.Get(id);
        //     if (inmobiliaria == null)
        //     {
        //         return NotFound("No se pudo encontrar la inmobiliaria");
        //     }
 
        //     await _service.Delete(inmobiliaria);
        //     return NoContent();
        // }
    }
}
