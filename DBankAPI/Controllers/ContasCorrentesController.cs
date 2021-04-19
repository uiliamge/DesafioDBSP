using System.Collections.Generic;
using System.Threading.Tasks;
using DBankAPI.Controllers;
using DBankAPI.Interfaces;
using DBankAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBank.Controllers
{
    [Authorize]
    public class ContasCorrentesController : ApiController
    {
        private readonly IContaCorrenteService _contaCorrenteService;

        public ContasCorrentesController(IContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        [HttpPost("EnviarDinheiro")]
        public IActionResult EnviarDinheiro([FromBody] LancamentoViewModel lancamentoViewModel)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(_contaCorrenteService.EnviarDinheiro(lancamentoViewModel));
        }

        [HttpGet("Extrato")]
        public async Task<IList<ExtratoViewModel>> GetExtrato(int contaCorrenteid)
        {
            return await _contaCorrenteService.GetExtrato(contaCorrenteid);
        }
    }
}
