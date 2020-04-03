using System.Threading.Tasks;
using Tenanpp.Repository.Models;

namespace Tenanpp.Core{
    public interface IInmobiliariaRepository : IRepository<Inmobiliaria>
    {
        Task Update(Inmobiliaria inmobiliaria, Inmobiliaria entity);
    }
}