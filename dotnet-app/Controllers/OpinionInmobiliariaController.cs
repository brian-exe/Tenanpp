using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tenanpp.Core.Service;
using Tenanpp.DAL.Models;
using Tenanpp.ApiResponses;
using Tenanpp.Models;
using Tenanpp.Models.Queries;

namespace Tenanpp.Controllers
{
    [Route("api/opiniones/inmobiliarias")]
    [ApiController]
    public class OpinionInmobiliariaController : Controller
    {
        private readonly IOpinionInmobiliariaService _service;
 
        public OpinionInmobiliariaController(IOpinionInmobiliariaService service)
        {
            _service = service;
        }

         
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id,[FromQuery] PaginationQuery parameters)
        {
            List<OpinionInmobiliaria> opiniones = await _service.GetOpinionesInmobiliaria(id, parameters);
 
            return Ok(new OkApiResponse(opiniones));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post(long id, [FromForm]OpinionInmobiliariaPost opinion){
            if(!ModelState.IsValid){
                return BadRequest(new BadRequestApiResponse("Los datos enviados no son correctos"));
            }
            return Ok(new OkApiResponse(HttpContext.Connection.RemoteIpAddress.ToString()));
            
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing && _service != null)
                _service.Dispose();
            base.Dispose(disposing);
        }
    }
}    