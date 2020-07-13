using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Tenanpp.DAL.Models;
using Tenanpp.Models.Queries;

namespace Tenanpp.Core.Service {
    public interface IOpinionInmobiliariaService: IBaseService<OpinionInmobiliaria>
    {
        Task<List<OpinionInmobiliaria>> GetOpinionesInmobiliaria(long inmobiliariaId, PaginationQuery parameters);
    }
}