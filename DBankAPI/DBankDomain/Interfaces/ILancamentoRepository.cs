using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBankAPI.Entities;

namespace DBankAPI.DBankDomain.Interfaces
{
    public interface ILancamentoRepository : IDisposable
    {
        void Add(Lancamento lancamento);
        void EnviarDinheiro(int contaOrigemId, Lancamento lancamento);
        Task<IEnumerable<Lancamento>> ListByNumeroContaCorrente(int numeroContaCorrente);

    }
}
