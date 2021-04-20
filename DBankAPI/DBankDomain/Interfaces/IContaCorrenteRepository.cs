using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBankAPI.Entities;

namespace DBankAPI.DBankDomain.Interfaces
{
    public interface IContaCorrenteRepository : IDisposable
    {
        ContaCorrente GetByNumero(int numero);
        ContaCorrente GetByUserName(string username);

    }
}
