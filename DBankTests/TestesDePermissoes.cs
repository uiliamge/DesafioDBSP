using System.Collections.Generic;
using DBankAPI.Interfaces;
using Xunit;

namespace DBankTests
{
    public class TestesDePermissoes
    {
        private readonly IContaCorrenteService _contaCorrenteService;

        public TestesDePermissoes(IContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        [Fact]
        public async void Contas_12345_NaoPodeVerLancamentosDeOutrasContas()
        {
            var contaNaoPodeVer = _contaCorrenteService.GetByNumero(123123);

            var extrato = await _contaCorrenteService.GetExtrato(12345);

            Assert.DoesNotContain(extrato, x => x.ContaCorrenteId == contaNaoPodeVer.Id);
        }
    }
}
