using Tenanpp.Core;
using System.Threading.Tasks;
using Tenanpp.Repository;

namespace Tenanpp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TenanppContext _context;

        public UnitOfWork(TenanppContext context)
        {
            _context = context;
            Inmobiliarias = new InmobiliariaRepository(_context);
        }

        public IInmobiliariaRepository Inmobiliarias { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}