using System.Threading.Tasks;
using System;
using Tenanpp.Core;
namespace Tenanpp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IInmobiliariaRepository Inmobiliarias { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}