using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBankAPI.Data;
using DBankAPI.DBankDomain.Interfaces;
using DBankAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBankAPI.DBankInfra.Data.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        protected readonly ApplicationDbContext _context;

        public LancamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
        }

        public void EnviarDinheiro(int contaOrigemId, Lancamento lancamento)
        {
            var contaDestino = _context.ContasCorrentes.Find(lancamento.ContaCorrenteId);

            //Debita minha conta
            Add(new Lancamento
            {
                Operacao = Enums.OperacaoEnum.Debito,
                ContaCorrenteId = contaOrigemId,
                DataHora = lancamento.DataHora,
                Valor = lancamento.Valor,
                Observacao = $"{lancamento.Observacao} (Referente à crédito na conta {contaDestino.Numero})"
            });

            //Credita no destino
            Add(new Lancamento
            {
                Operacao = Enums.OperacaoEnum.Credito,
                ContaCorrenteId = lancamento.ContaCorrenteId,
                DataHora = lancamento.DataHora,
                Valor = lancamento.Valor,
                Observacao = lancamento.Observacao
            });

            _context.SaveChanges();
        }

        public async Task<IEnumerable<Lancamento>> ListByNumeroContaCorrente(int numeroContaCorrente)
        {
            var conta = await _context.ContasCorrentes.FirstOrDefaultAsync();

            return await _context.Lancamentos.Where(x => x.ContaCorrenteId == conta.Id)
                .OrderBy(x => x.DataHora)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
