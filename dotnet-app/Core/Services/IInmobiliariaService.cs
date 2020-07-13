using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Tenanpp.DAL.Models;
using Tenanpp.Models.Queries;

namespace Tenanpp.Core.Service {
    public interface IInmobiliariaService: IBaseService<Inmobiliaria>
    {
        Task<FotoPerfil> GetFoto(int id);
        Task<List<Inmobiliaria>> Get(PaginationQuery parameters);
    }
}