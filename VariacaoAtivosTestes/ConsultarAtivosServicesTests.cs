using Xunit;
using Moq;
using VariacaoAtivoApi.DTOs;
using VariacaoAtivoApi.Models;
using VariacaoAtivoApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VariacaoAtivosApi.Tests
{
    public class ConsultarAtivosServicesTests
    {
        private readonly Mock<IVariacaoAtivosService> _mockVariacaoAtivosService;
        private readonly ConsultarAtivosServices _consultarAtivosServices;

        public ConsultarAtivosServicesTests()
        {
            _mockVariacaoAtivosService = new Mock<IVariacaoAtivosService>();
            _consultarAtivosServices = new ConsultarAtivosServices(_mockVariacaoAtivosService.Object);
        }

        [Fact]
        public async Task ConsultarAtivo_ReturnsCorrectList()
        {
            // Arrange
            var consultaAtivo = new ConsultarAtivoQueryDto("PETR4.SA","1d","30d");
            var variacaoAtivosList = new List<VariacaoAtivos> { new VariacaoAtivos { Nome = "PETR4.SA" } };
            _mockVariacaoAtivosService.Setup(s => s.ConvertToVariacaoAtivosList(It.IsAny<AtivosResponseDto>())).ReturnsAsync(variacaoAtivosList);
            _mockVariacaoAtivosService.Setup(s => s.SaveVariacoesAtivosIfNotExists(It.IsAny<List<VariacaoAtivos>>())).Returns(Task.CompletedTask);

            // Act
            var result = await _consultarAtivosServices.ConsultarAtivo(consultaAtivo);

            // Assert
            Assert.Equal(variacaoAtivosList, result);
        }
    }
}
