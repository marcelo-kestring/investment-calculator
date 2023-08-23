using InvestmentCalculatorBackend.Business;
using InvestmentCalculatorBackend.Controllers;
using InvestmentCalculatorBackend.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace InvestmentCalculator.UnitTests
{
    public class RendimentoControllerUnitTest
    {
        private readonly InvestimentosController investimentosController;
        private readonly Mock<IRendimentoService> rendimentoServiceMock;
        private readonly Mock<ILogger<InvestimentosController>> loggerMock;

        public RendimentoControllerUnitTest()
        {
            rendimentoServiceMock = new Mock<IRendimentoService>();
            loggerMock = new Mock<ILogger<InvestimentosController>>();

            investimentosController = new InvestimentosController(loggerMock.Object, rendimentoServiceMock.Object);
        }

        [Fact(DisplayName = "Calcular Investimento")]
        public void TestCalcularInvestimento()
        {
            // Arrange
            var amount = 1000.0;
            var months = 12;

            var expectedGrossResult = 1123.08D;
            var expectedNetResult = 1098.47D;

            var rendimentoResult = new RendimentoResult()
            {
                ResultadoBruto = 1123.09D,
                ResultadoLiquido = 1098.46D,
            };

            rendimentoServiceMock.Setup(x => x.CalcularInvestimento(It.IsAny<double>(), It.IsAny<int>()))
                .Returns(rendimentoResult);

            // Act
            OkObjectResult okObjectResult = (OkObjectResult)investimentosController.CalcularInvestimento(amount, months);
            RendimentoResult result = new();
            if (okObjectResult.Value != null)
            {
                result = (RendimentoResult)okObjectResult.Value;
            }

            // Assert
            Assert.NotNull(okObjectResult.Value);
            Assert.Equal(expectedGrossResult, result.ResultadoBruto, 0.01);
            Assert.Equal(expectedNetResult, result.ResultadoLiquido, 0.01);
        }
    }
}