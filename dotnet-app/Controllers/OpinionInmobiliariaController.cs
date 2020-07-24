using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tenanpp.Core.Service;
using Tenanpp.DAL.Models;
using Tenanpp.ApiResponses;
using Tenanpp.Models;
using Tenanpp.Services;
using Tenanpp.Models.Queries;
using AutoMapper;

namespace Tenanpp.Controllers
{
    [Route("api/opiniones/inmobiliarias")]
    [ApiController]
    public class OpinionInmobiliariaController : Controller
    {
        private readonly IOpinionInmobiliariaService _service;
        private readonly IInmobiliariaService _serviceInmo;
        private protected IMapper _mapper;
 
        public OpinionInmobiliariaController(IInmobiliariaService serviceInmo, IOpinionInmobiliariaService service, IMapper mapper)
        {
            _serviceInmo = serviceInmo;
            _service = service;
            _mapper = mapper;
        }

         
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOpinionesForInmobiliaria(long id,[FromQuery] OpinionesForInmobiliariaQuery parameters)
        {
            List<OpinionInmobiliariaGet> opiniones = await _service.GetOpinionesInmobiliaria(id, parameters);
 
            return Ok(new OkApiResponse(opiniones));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post(long id, [FromBody]OpinionInmobiliariaPost opinion){
            Inmobiliaria inmo = await _serviceInmo.GetById(id);
            if(inmo == null){
                return BadRequest(new BadRequestApiResponse("No se encontró inmobiliaria con el Id ingresado"));
            }

            var clientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            if(! await _service.IsPossibleToCreateANewOpinionFor(id, clientIpAddress)){
                return BadRequest(new BadRequestApiResponse("Ya se detectó otra opinion ingresada en el dia de hoy para la misma inmobiliaria y proveniente de la misma IP"));
            }
            opinion.IpOrigen = clientIpAddress;
            
            OpinionInmobiliaria createdOpinion = await _service.AddOpinionInmobiliaria(id,opinion);
            if(createdOpinion != null)
                return Ok(new OkApiResponse(createdOpinion));
            else
                return Conflict(new InternalErrorResponse("No se pudo completar la operación"));
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing ){
                if(_service != null)
                    _service.Dispose();

                if(_serviceInmo != null)
                    _serviceInmo.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}    