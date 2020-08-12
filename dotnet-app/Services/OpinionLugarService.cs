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
    public class OpinionLugarService : BaseService<OpinionLugar>, IOpinionLugarService{
        public OpinionLugarService(IMapper mapper,TenanppContext context): base(mapper, context)
        {
            
        }

        public async Task<List<OpinionLugar>> GetOpinionesfor(long id){
            return await _context.OpinionesLugares.Where(o => o.LugarId == id).ToListAsync();
        }

        public async Task<OpinionLugar> AddOpinionFor(long lugarId, OpinionLugarPost model){
            OpinionLugar newOpinion = _mapper.Map<OpinionLugar>(model);
            newOpinion.LugarId = lugarId;
            await _context.OpinionesLugares.AddAsync(newOpinion);
            await _context.SaveChangesAsync();
            return newOpinion;
        }
        
        //public async Task<List<OpinionLugar>> GetFromLocation(Point coord){
        //     return await _context.OpinionesLugares.Where(o => o. == id).ToListAsync();
        // }
    }
}