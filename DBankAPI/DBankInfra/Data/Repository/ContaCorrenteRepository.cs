using System.Linq;
using DBankAPI.Data;
using DBankAPI.DBankDomain.Interfaces;
using DBankAPI.Entities;

namespace DBankAPI.DBankInfra.Data.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        protected readonly ApplicationDbContext _context;

        public ContaCorrenteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ContaCorrente GetByNumero(int numero)
        {
            return _context.ContasCorrentes.FirstOrDefault(x => x.Numero == numero);
        }

        public ContaCorrente GetByUserId(string userId)
        {
            return _context.ContasCorrentes.FirstOrDefault(x => x.UserId == userId);
        }

        public void Dispose()
        {
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
