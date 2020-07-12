using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Tenanpp.DAL.Models;
using Tenanpp.Models.Queries;

namespace Tenanpp.Core.Service {
    public interface IInmobiliariaService<TEntity>: IBaseService<TEntity>
                where TEntity : class  {
        Task<FotoPerfil> GetFoto(int id);
        Task<List<Inmobiliaria>> Get(GetInmobiliariasQuery parameters);
    }
}