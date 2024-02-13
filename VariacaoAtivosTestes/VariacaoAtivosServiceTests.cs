using Moq;
using VariacaoAtivoApi.DTOs;
using VariacaoAtivoApi.Models;
using VariacaoAtivoApi.Services;
using VariacaoAtivoApi.Repositories;

namespace VariacaoAtivosApi.Tests
{
    public class VariacaoAtivosServiceTests
    {
        private readonly Mock<IVariacaoAtivosRepository> _mockVariacaoAtivosRepository;
        private readonly VariacaoAtivosService _variacaoAtivosService;

        public VariacaoAtivosServiceTests()
        {
            _mockVariacaoAtivosRepository = new Mock<IVariacaoAtivosRepository>();
            _variacaoAtivosService = new VariacaoAtivosService(_mockVariacaoAtivosRepository.Object);
        }

        [Fact]
        public async Task ConvertToVariacaoAtivosList_ReturnsCorrectList()
        {
            // Arrange
            var adto = new AtivosResponseDto
            {
                Chart = new Chart
                {
                    Result = new List<Result>
                    {
                        new Result
                        {
                            Meta = new Meta { Symbol = "Teste" },
                            Timestamp = new List<long> { 1617235200 },
                            Indicators = new Indicators
                            {
                                Quote = new List<Quote>
                                {
                                    new Quote { Open = new List<decimal> { 10.0m } }
                                }
                            }
                        }
                    }
                }
            };
            var expected = new List<VariacaoAtivos>
            {
                new VariacaoAtivos
                {
                    Nome = "Teste",
                    Dia = 1,
                    Data = DateTimeOffset.FromUnixTimeSeconds(1617235200).UtcDateTime,
                    Valor = 10.0m,
                    VariacaoD1 = 0,
                    VariacaoInicio = 0
                }
            };

            // Act
            var result = await _variacaoAtivosService.ConvertToVariacaoAtivosList(adto);

            // Assert
            Assert.Equal(expected[0].Nome, result[0].Nome);
            Assert.Equal(expected[0].Dia, result[0].Dia);
            Assert.Equal(expected[0].Data, result[0].Data);
            Assert.Equal(expected[0].Valor, result[0].Valor);
            Assert.Equal(expected[0].VariacaoD1, result[0].VariacaoD1);
            Assert.Equal(expected[0].VariacaoInicio, result[0].VariacaoInicio);
        }
    }
}
