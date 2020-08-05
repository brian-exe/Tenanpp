using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tenanpp.Core.Service;
using Tenanpp.DAL.Models;
using Tenanpp.ApiResponses;
using Tenanpp.Models.Queries;
using Tenanpp.Models;
using System;
using AutoMapper;

namespace Tenanpp.Controllers
{
    [Route("api/inmobiliarias")]
    [ApiController]
    public class InmobiliariaController : Controller
    {
        private readonly IInmobiliariaService _service;
         private protected IMapper _mapper;
 
        public InmobiliariaController(IInmobiliariaService service, IMapper mapper )
        {
            _service = service;
            _mapper = mapper;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationQuery parameters)
        {
            IEnumerable<Inmobiliaria> inmobiliarias = await _service.Get(parameters);
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

        [Route("image/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetInmobiliariaImage(int id)
        {
            FotoPerfil foto = await _service.GetFoto(id);
            if (foto == null)
            {
                return NotFound( new NotFoundApiResponse("No se encontró foto"));
            }
            return File(foto.Data, "image/png", "");
        }


        [HttpGet("estadisticas/{id}")]
        public async Task<IActionResult> GetEstadisticasInmobiliaria(long id)
        {
            EstadisticasInmobiliaria estadisticas = await _service.GetEstadisticasInmobiliaria(id);

            return Ok(new OkApiResponse(estadisticas));
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> SearchInmobiliaria([FromQuery] string nombre)
        {
            /*En condiciones normales, nunca deberia entrar en este if*/
            if(nombre =="" || nombre == null || nombre.Length < 3)
                return NotFound( new NotFoundApiResponse("La entrada recibida no es válida"));

            List<Inmobiliaria> inmobiliarias = await _service.GetByNombre(nombre);
            /*if(inmobiliarias.Count <= 0)
                return NotFound( new NotFoundApiResponse("No se encontraron resultados"));*/
            List<InmobiliariaSearch> result = _mapper.Map<List<Inmobiliaria>,List<InmobiliariaSearch>>(inmobiliarias);

            return Ok(new OkApiResponse(result));
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
