using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DBankAPI.DBankDomain.Commands;
using DBankAPI.DBankDomain.Interfaces;
using DBankAPI.Entities;
using DBankAPI.Interfaces;
using DBankAPI.ViewModels;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace DBankAPI.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IMapper _mapper;
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IMediatorHandler _mediator;

        public ContaCorrenteService(IMapper mapper, ILancamentoRepository lancamentoRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _lancamentoRepository = lancamentoRepository;
        }

        public RetornoViewModel EnviarDinheiro(LancamentoViewModel lancamentoViewModel)
        {
            try
            {
                var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel);
                _lancamentoRepository.EnviarDinheiro(lancamentoViewModel.ContaCorrenteOrigemId, lancamento);

                return new RetornoViewModel
                {
                    Message = "Enviado"
                };

            }
            catch (Exception ex)
            {
                return new RetornoViewModel
                {
                    Error = true,
                    Message = ex.ToString()
                };
            }
        }


        public async Task<List<ExtratoViewModel>> GetExtrato(int contaCorrenteId)
        {
            var lancamentos = await _lancamentoRepository.ListByContaCorrente(contaCorrenteId);
            return _mapper.Map<List<ExtratoViewModel>>(lancamentos);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
