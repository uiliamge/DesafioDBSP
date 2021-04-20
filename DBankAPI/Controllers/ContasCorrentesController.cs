using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using DBankAPI.Controllers;
using DBankAPI.Interfaces;
using DBankAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Jwt;

namespace DBank.Controllers
{
    [Authorize]
    [Route("api/ContasCorrentes")]
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
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.Claims.ToList()[0].Value;

            if (!User.IsInRole("Admin"))
            {
                if (!_contaCorrenteService.ContaPertenceAoUsuario(userId, lancamentoViewModel.ContaCorrenteOrigem))
                    return BadRequest("Esta conta não pode ser movimentada por este usuário");
            }

            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(_contaCorrenteService.EnviarDinheiro(lancamentoViewModel));
        }

        [HttpGet("Extrato")]
        public async Task<IActionResult> GetExtrato(int numeroContaCorrente)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.Claims.ToList()[0].Value;

            if (!User.IsInRole("Admin"))
            {
                if (!_contaCorrenteService.ContaPertenceAoUsuario(userId, numeroContaCorrente))
                    return BadRequest("Esta conta não pode ser acessda por este usuário");
            }

            return Ok(await _contaCorrenteService.GetExtrato(numeroContaCorrente));
        }
    }
}
