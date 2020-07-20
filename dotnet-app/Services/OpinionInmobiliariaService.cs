using Tenanpp.DAL.Models;
using Tenanpp.DAL;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tenanpp.Core.Service;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tenanpp.Models.Queries;
using Tenanpp.Models;
using AutoMapper;
using System;

namespace Tenanpp.Services{
    public class OpinionInmobiliariaService : BaseService<OpinionInmobiliaria>, IOpinionInmobiliariaService{
        public OpinionInmobiliariaService(IMapper mapper,TenanppContext context): base(mapper, context)
        {
            
        }
        public async Task<List<OpinionInmobiliaria>> GetOpinionesInmobiliaria(long inmobiliariaId, PaginationQuery parameters){

            int skip = (parameters.PageNumber - 1) * parameters.PageSize;
            return await _context.OpinionesInmobiliarias
                    .Where(o => o.InmobiliariaId == inmobiliariaId)
                    .Skip(skip)
                    .Take(parameters.PageSize)
                    .OrderBy(i => i.Id)
                    .ToListAsync();
        }

        public async Task<OpinionInmobiliaria> AddOpinionInmobiliaria(long inmobiliariaId, OpinionInmobiliariaPost model){
            OpinionInmobiliaria newOpinion = _mapper.Map<OpinionInmobiliaria>(model);
            newOpinion.FechaOpinion = DateTime.Today;
            newOpinion.InmobiliariaId = inmobiliariaId;
            await _context.OpinionesInmobiliarias.AddAsync(newOpinion);
            await _context.SaveChangesAsync();
            return newOpinion;
        }

        public async Task<bool> IsPossibleToCreateANewOpinionFor(long id, string clientIpAddress){
            List<OpinionInmobiliaria> result = await _context.OpinionesInmobiliarias
                    .Where(o => o.InmobiliariaId == id)
                    .Where(o => o.IpOrigen == clientIpAddress)
                    .ToListAsync();
            result = result.Where(o => o.FechaOpinion.Date == DateTime.Today.Date).ToList();

            return result.Count() == 0;
        }
    }
}