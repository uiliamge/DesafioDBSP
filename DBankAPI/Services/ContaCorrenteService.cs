using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DBankAPI.DBankDomain.Interfaces;
using DBankAPI.Entities;
using DBankAPI.Interfaces;
using DBankAPI.ViewModels;

namespace DBankAPI.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IMapper _mapper;
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IMapper mapper, ILancamentoRepository lancamentoRepository, IContaCorrenteRepository contaCorrenteRepository)
        {
            _mapper = mapper;
            _lancamentoRepository = lancamentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public bool ContaPertenceAoUsuario(string userId, int numeroContaCorrente)
        {
            var contaCorrente = _contaCorrenteRepository.GetByNumero(numeroContaCorrente);
            return (contaCorrente.UserId == userId);
        }

        public RetornoViewModel EnviarDinheiro(LancamentoViewModel lancamentoViewModel)
        {
            try
            {
                var contaOrigem = _contaCorrenteRepository.GetByNumero(lancamentoViewModel.ContaCorrenteOrigem);
                var contaDestino = _contaCorrenteRepository.GetByNumero(lancamentoViewModel.ContaCorrenteDestino);

                var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel);
                lancamento.DataHora = DateTime.Now;
                lancamento.ContaCorrenteId = contaDestino.Id;

                _lancamentoRepository.EnviarDinheiro(contaOrigem.Id, lancamento);

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

        public async Task<List<ExtratoViewModel>> GetExtrato(int numeroContaCorrente)
        {
            var lancamentos = await _lancamentoRepository.ListByNumeroContaCorrente(numeroContaCorrente);
            return _mapper.Map<List<ExtratoViewModel>>(lancamentos);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
