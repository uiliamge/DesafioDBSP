using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBankAPI.ViewModels;
using FluentValidation.Results;

namespace DBankAPI.Interfaces
{
    public interface IContaCorrenteService : IDisposable
    {
        RetornoViewModel EnviarDinheiro(LancamentoViewModel lancamentoViewModel);
        Task<List<ExtratoViewModel>> GetExtrato(int contaCorrenteId);
    }
}


