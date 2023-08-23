using InvestmentCalculatorBackend.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace InvestmentCalculatorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class InvestimentosController : ControllerBase
    {
        private readonly ILogger<InvestimentosController> _logger;
        private readonly IRendimentoService _rendimentoService;

        public InvestimentosController(
            ILogger<InvestimentosController> logger, 
            IRendimentoService rendimentoService)
        {
            _logger = logger;
            _rendimentoService = rendimentoService;
        }

        [HttpGet("calculo/cdb")]
        [AllowAnonymous]
        public IActionResult CalcularInvestimento(double valor, int prazo)
        {
            var resultado = _rendimentoService.CalcularInvestimento(valor, prazo);

            _logger.LogInformation("CalcularInvestimento realizado!");

            return Ok(resultado);
        }
    }
}
