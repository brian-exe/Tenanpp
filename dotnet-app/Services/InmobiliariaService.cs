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
        // public async override Task<int> Add(Inmobiliaria entity){
        //     await _unitOfWork.Inmobiliarias.Add(entity);
        //     return await _unitOfWork.CompleteAsync();
        // }
        // public async override Task<int> Delete(Inmobiliaria entity){
        //     await _unitOfWork.Inmobiliarias.Delete(entity);
        //     return _unitOfWork.CompleteAsync();
        // }

        // public async override Task<int> Update(Inmobiliaria dbEntity, Inmobiliaria entityForUpdate){
        //     dbEntity.Nombre = entityForUpdate.Nombre;
        //     dbEntity.Direccion = entityForUpdate.Direccion;
        //     dbEntity.Localidad = entityForUpdate.Localidad;
        //     dbEntity.Telefono = entityForUpdate.Telefono;
        //     dbEntity.Cuit = entityForUpdate.Cuit;
        //     dbEntity.Url = entityForUpdate.Url;
        //     return await _unitOfWork.CompleteAsync();
        // }
    }

}