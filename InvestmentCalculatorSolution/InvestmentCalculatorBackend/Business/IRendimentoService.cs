using InvestmentCalculatorBackend.Result;

namespace InvestmentCalculatorBackend.Business
{
    public interface IRendimentoService
    {
        public RendimentoResult CalcularInvestimento(double valor, int prazo);
    }
}
