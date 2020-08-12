using Tenanpp.DAL.Models;
using Tenanpp.DAL;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tenanpp.Core.Service;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tenanpp.Models.Queries;
using AutoMapper;
using Microsoft.Data.SqlClient;

namespace Tenanpp.Services{
    public class InmobiliariaService : BaseService<Inmobiliaria>, IInmobiliariaService{

        public InmobiliariaService(IMapper mapper,TenanppContext context): base(mapper, context)
        {
        }

        public async Task<FotoPerfil> GetFoto(int id){
            return await _context.FotosPerfil.Where(f => f.InmobiliariaId ==id).FirstOrDefaultAsync();
        }

        public async Task<List<Inmobiliaria>> GetByNombre(string nombre){
            return await _context.Inmobiliarias
                    .Where(x => x.Nombre
                            .ToLower()
                            .Contains(nombre.ToLower()))
                    .ToListAsync();
        }

        public async Task<List<Inmobiliaria>> Get(PaginationQuery parameters){
            int skip = (parameters.PageNumber - 1) * parameters.PageSize;
            return await _context.Inmobiliarias
                    .Skip(skip)
                    .Take(parameters.PageSize)
                    .OrderBy(i => i.Id)
                    .ToListAsync();
        }

        public async Task<EstadisticasInmobiliaria> GetEstadisticasInmobiliaria(long id){
            var param = new SqlParameter("@id", id);
            List<EstadisticasInmobiliaria> estadisticas =
                        await _context
                        .Set<EstadisticasInmobiliaria>()
                            .FromSqlRaw("EstadisticasInmobiliaria @id={0}",id)
                                .ToListAsync();
                                
            return estadisticas.FirstOrDefault();
        }
    }

}