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
    [Route("api/lugares")]
    [ApiController]
    public class LugaresController : Controller
    {
        private readonly IOpinionLugarService _opiService;
        private readonly ILugaresService _service;
         private protected IMapper _mapper;
 
        public LugaresController(ILugaresService service, IOpinionLugarService opiService, IMapper mapper )
        {
            _service = service;
            _opiService = opiService;
            _mapper = mapper;
        }
 
        [HttpPost]
        public async Task<IActionResult> InsertOpinion([FromBody] InsertOpinionLugarPost model)
        {
            Lugar lugar = await _service.GetByDireccion(model.lugar.Direccion);
            if(lugar == null){
                lugar = await _service.AddLugar(model.lugar);
            }

            OpinionLugar opinion = await _opiService.AddOpinionFor(lugar.Id, model.opinion);
            if(opinion !=null)
                return Ok( new OkApiResponse(opinion));

            return BadRequest(new InternalErrorResponse(""));
        }

        [HttpPost("opiniones")]
        public async Task<IActionResult> GetOpinionesForDireccion([FromBody] OpinionLugarSearch model){
            Lugar lugar = await _service.GetByDireccion(model.Direccion);
            List<OpinionLugar> opiniones= new List<OpinionLugar>();

            if(lugar == null){
                return Ok( new OkApiResponse(opiniones));
            }

            opiniones = await _opiService.GetOpinionesfor(lugar.Id);
            return Ok( new OkApiResponse(opiniones));
        }
 
        protected override void Dispose(bool disposing)
        {
            if(disposing ){
                if(_service != null)
                    _service.Dispose();

                if(_opiService != null)
                    _opiService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
