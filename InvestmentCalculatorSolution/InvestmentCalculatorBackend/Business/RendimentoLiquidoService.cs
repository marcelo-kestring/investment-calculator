namespace InvestmentCalculatorBackend.Business
{
    public class RendimentoLiquidoService : IRendimentoLiquidoService
    {
        public double CalcularRendimentoLiquido(double rendimentoBruto, int prazo)
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
