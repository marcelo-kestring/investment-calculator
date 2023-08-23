namespace InvestmentCalculatorBackend.Business
{
    public interface IRendimentoLiquidoService
    {
        public double CalcularRendimentoLiquido(double rendimentoBruto, int prazo);
    }
}
