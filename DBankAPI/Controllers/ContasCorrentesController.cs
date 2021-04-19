using System.Collections.Generic;
using System.Threading.Tasks;
using DBankAPI.Controllers;
using DBankAPI.Interfaces;
using DBankAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DBank.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(Roles = "Clientes")]
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
