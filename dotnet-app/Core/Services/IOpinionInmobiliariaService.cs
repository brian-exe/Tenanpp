using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Tenanpp.DAL.Models;
using Tenanpp.Models.Queries;
using Tenanpp.Models;

namespace Tenanpp.Core.Service {
    public interface IOpinionInmobiliariaService: IBaseService<OpinionInmobiliaria>
    {
        Task<List<OpinionInmobiliaria>> GetOpinionesInmobiliaria(long inmobiliariaId, OpinionesForInmobiliariaQuery parameters);
        Task<OpinionInmobiliaria> AddOpinionInmobiliaria(long inmobiliariaId, OpinionInmobiliariaPost model);
        Task<bool> IsPossibleToCreateANewOpinionFor(long id, string clientIpAddress);
    }
}