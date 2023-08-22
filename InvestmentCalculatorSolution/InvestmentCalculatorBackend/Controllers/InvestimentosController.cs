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

        private const double TB = 1.08;  // 108%
        private const double CDI = 0.009; // 0.9%

        [HttpGet("calculo/cdb")]
        [AllowAnonymous]
        public IActionResult CalcularInvestimento(double valor, int prazo)
        {
            double valorFinal = valor;
            double usoCDI = CDI * TB;

            for (int i = 0; i < prazo; i++)
            {
                valorFinal *= 1 + usoCDI;
            }

            double rendimentoBruto = valorFinal - valor;
            double valorLiquido = valor;
            valorLiquido += CalcularRendimentoLiquido(rendimentoBruto, prazo);

            var resultado = new
            {
                resultadoBruto = valorFinal,
                resultadoLiquido = valorLiquido
            };

            return Ok(resultado);
        }

        private double CalcularRendimentoLiquido(double rendimentoBruto, int prazo)
        {
            double imposto;

            if (prazo <= 6)
            {
                imposto = 0.225; // 22.5%
            }
            else if (prazo <= 12)
            {
                imposto = 0.20; // 20%
            }
            else if (prazo <= 24)
            {
                imposto = 0.175; // 17.5%
            }
            else
            {
                imposto = 0.15; // 15%
            }

            return rendimentoBruto * (1 - imposto);
        }
    }
}
