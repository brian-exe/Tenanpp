using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Tenanpp.DAL.Models;
using Tenanpp.Models;
using  NetTopologySuite.Geometries;

namespace Tenanpp.Core.Service {
    public interface IOpinionLugarService: IBaseService<OpinionLugar>
    {
        Task<List<OpinionLugar>> GetOpinionesfor(long id);
        //Task<List<OpinionLugar>> GetFromLocation(Point coord);
        Task<OpinionLugar> AddOpinionFor(long Id, OpinionLugarPost model);
    }
}