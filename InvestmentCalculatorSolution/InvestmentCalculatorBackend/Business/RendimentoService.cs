using InvestmentCalculatorBackend.Result;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentCalculatorBackend.Business
{
    public class RendimentoService : IRendimentoService
    {
        private const double TB = 1.08;  // 108%
        private const double CDI = 0.009; // 0.9%

        private readonly IRendimentoLiquidoService _rendimentoLiquidoService;

        public RendimentoService(IRendimentoLiquidoService rendimentoLiquidoService)
        {
            _rendimentoLiquidoService = rendimentoLiquidoService;
        }

        public RendimentoResult CalcularInvestimento(double valor, int prazo) 
        {
            double valorFinal = valor;
            double usoCDI = CDI * TB;

            for (int i = 0; i < prazo; i++)
            {
                valorFinal *= 1 + usoCDI;
            }

            double rendimentoBruto = valorFinal - valor;
            double valorLiquido = valor;
            valorLiquido += _rendimentoLiquidoService.CalcularRendimentoLiquido(rendimentoBruto, prazo);

            return new RendimentoResult(valorFinal, valorLiquido);
        }
    }
}
