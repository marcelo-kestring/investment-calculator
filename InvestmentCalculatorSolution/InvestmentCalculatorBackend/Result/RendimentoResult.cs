namespace InvestmentCalculatorBackend.Result
{
    public class RendimentoResult
    {
        public RendimentoResult()
        {
        }

        public RendimentoResult(double resultadoBruto, double resultadoLiquido)
        {
            this.ResultadoBruto = resultadoBruto;
            this.ResultadoLiquido = resultadoLiquido;
        }

        public double ResultadoBruto { get; set; }
        public double ResultadoLiquido { get; set; }
    }
}
