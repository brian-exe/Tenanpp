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
using Microsoft.Data.SqlClient;

namespace Tenanpp.Services{
    public class OpinionInmobiliariaService : BaseService<OpinionInmobiliaria>, IOpinionInmobiliariaService{
        public OpinionInmobiliariaService(IMapper mapper,TenanppContext context): base(mapper, context)
        {
            
        }
        public async Task<List<OpinionInmobiliariaGet>> GetOpinionesInmobiliaria(long inmobiliariaId, OpinionesForInmobiliariaQuery parameters){
            int skip = (parameters.PageNumber - 1) * parameters.PageSize;

            IQueryable<OpinionInmobiliaria> query =_context.OpinionesInmobiliarias.Where(o => o.InmobiliariaId == inmobiliariaId);
            
            if(parameters.OpinionId !=null){
                query = query.Where(o => o.Id == parameters.OpinionId);
            }
            
            List<OpinionInmobiliaria> result = await query.Skip(skip)
                    .Take(parameters.PageSize)
                    .OrderBy(i => i.Id)
                    .ToListAsync();
            return _mapper.Map<List<OpinionInmobiliaria>,List<OpinionInmobiliariaGet>>(result);
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
            result = result.Where(o => o.FechaOpinion.DayOfYear == DateTime.Today.DayOfYear).ToList();

            return result.Count() == 0;
        }


        public async Task<List<RankingGeneral>> GetRankingGeneral(){             
            return await _context.RankingGeneral.ToListAsync();
        }
        public async Task<List<RankingConductaEtica>> GetRankingConductaEtica(){
            return await _context.RankingConductaEtica.ToListAsync();
        }
        public async Task<List<RankingResponsabilidad>> GetRankingResponsabilidad(){
            return await _context.RankingResponsabilidad.ToListAsync();
        }
        public async Task<List<RankingAtencion>> GetRankingAtencion(){
            return await _context.RankingAtencion.ToListAsync();
        }
    }
}