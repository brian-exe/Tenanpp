using Tenanpp.DAL.Models;
using Tenanpp.DAL;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tenanpp.Core.Service;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Data.SqlClient;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using Tenanpp.Models;

namespace Tenanpp.Services{
    public class LugaresService : BaseService<Lugar>, ILugaresService{
        public LugaresService(IMapper mapper,TenanppContext context): base(mapper, context)
        {
            
        }

        public async Task<Lugar> GetByDireccion(string direccion){
            return await _context.Lugares.Where(l => l.Direccion == direccion).FirstOrDefaultAsync();
        }

        public async Task<Lugar> AddLugar(LugarPost model){
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            Lugar newLugar = _mapper.Map<LugarPost,Lugar>(model);
            newLugar.Location = geometryFactory.CreatePoint(new Coordinate(model.Latitude, model.Longitude));

            await _context.Lugares.AddAsync(newLugar);
            await _context.SaveChangesAsync();

            return newLugar;

        }
        public async Task<Lugar> GetFromLocation(Point coord){
            return new Lugar();
        }
        public async Task<List<Lugar>> GetNearLugaresTo(LugarPost model){
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            Point coord = geometryFactory.CreatePoint(new Coordinate(model.Latitude, model.Longitude));

            var result = await _context.Lugares
                            .OrderBy(l => l.Location.Distance(coord))
                            .Where(l => l.Location.IsWithinDistance(coord,0.005))// 0.005 --> 5cuadras
                            .ToListAsync();
            return result;
        }
    }
}