using InvestmentCalculatorBackend.Business;
using Moq;

namespace InvestmentCalculator.UnitTests
{
    public class RendimentoUnitTest
    {
        private readonly RendimentoService rendimentoService;
        private readonly RendimentoLiquidoService rendimentoLiquidoService;
        private readonly Mock<IRendimentoLiquidoService> rendimentoLiquidoServiceMock;

        public RendimentoUnitTest()
        {
            rendimentoLiquidoServiceMock = new Mock<IRendimentoLiquidoService>();

            rendimentoService = new RendimentoService(rendimentoLiquidoServiceMock.Object);
            rendimentoLiquidoService = new RendimentoLiquidoService();
        }

        [Fact(DisplayName = "Calcular Investimento")]
        public void TestCalcularInvestimento()
        {
            // Arrange
            var amount = 1000.0;
            var months = 12;

            var expectedGrossResult = 1123.08D;
            var expectedNetResult = 1098.47D;

            rendimentoLiquidoServiceMock.Setup(x => x.CalcularRendimentoLiquido(It.IsAny<double>(), It.IsAny<int>()))
                .Returns(98.47D);

            // Act
            var result = rendimentoService.CalcularInvestimento(amount, months);

            // Assert
            Assert.Equal(expectedGrossResult, result.ResultadoBruto, 0.01);
            Assert.Equal(expectedNetResult, result.ResultadoLiquido, 0.01);
        }

        [Theory(DisplayName = "Calcular Investimento Liquido")]
        [InlineData( 95.387D, 6)]
        [InlineData( 98.464D, 12)]
        [InlineData(101.541D, 24)]
        [InlineData(104.618D, 25)]
        public void TestCalcularRendimentoLiquido(double expectedResult, int months)
        {
            // Arrange
            var income = 123.08D;

            rendimentoLiquidoServiceMock.Setup(x => x.CalcularRendimentoLiquido(It.IsAny<double>(), It.IsAny<int>()))
                .Returns(1123.08D);

            // Act
            var result = rendimentoLiquidoService.CalcularRendimentoLiquido(income, months);

            // Assert
            Assert.Equal(expectedResult, result, 0.01);
        }
    }
}