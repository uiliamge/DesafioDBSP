using System.Collections.Generic;
using System.Threading.Tasks;
using DBankAPI.Controllers;
using DBankAPI.Interfaces;
using DBankAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DBank.Controllers
{
    //[Authorize]
    public class ContasCorrentesController : ApiController
    {
        private readonly IContaCorrenteService _contaCorrenteService;

        public ContasCorrentesController(IContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        [HttpPost("EnviarDinheiro")]
        public IActionResult EnviarDinheiro(LancamentoViewModel lancamentoViewModel)
        {
            if (!User.IsInRole("Admin"))
            {
                if (!_contaCorrenteService.ContaPertenceAoUsuario(User.Identity.Name, lancamentoViewModel.ContaCorrenteOrigem))
                    return BadRequest("Esta conta não pode ser movimentada por este usuário");
            }

            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(_contaCorrenteService.EnviarDinheiro(lancamentoViewModel));
        }

        [HttpGet("Extrato")]
        public async Task<IActionResult> GetExtrato(int numeroContaCorrente)
        {
            if (!User.IsInRole("Admin"))
            {
                if (!_contaCorrenteService.ContaPertenceAoUsuario(User.Identity.Name, numeroContaCorrente))
                    return BadRequest("Esta conta não pode ser acessada por este usuário");
            }

            return Ok(await _contaCorrenteService.GetExtrato(numeroContaCorrente));
        }
    }
}
