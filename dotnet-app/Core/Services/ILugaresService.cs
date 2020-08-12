using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Tenanpp.DAL.Models;
using Tenanpp.Models;
using  NetTopologySuite.Geometries;

namespace Tenanpp.Core.Service {
    public interface ILugaresService: IBaseService<Lugar>
    {
        Task<Lugar> GetByDireccion(string direccion);
        Task<Lugar> GetFromLocation(Point coord);
        Task<List<Lugar>> GetNearLugaresTo(LugarPost model);
        Task<Lugar> AddLugar(LugarPost model);
    }
}