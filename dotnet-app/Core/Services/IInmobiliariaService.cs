using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Tenanpp.DAL.Models;

namespace Tenanpp.Core.Service {
    public interface IInmobiliariaService<TEntity>: IBaseService<TEntity>
                where TEntity : class  {
        Task<FotoPerfil> GetFoto(int id);
    }
}