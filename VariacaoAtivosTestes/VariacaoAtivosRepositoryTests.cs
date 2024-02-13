using Microsoft.EntityFrameworkCore;
using VariacaoAtivoApi.Data;
using VariacaoAtivoApi.Models;
using VariacaoAtivosApi.Repositories;

namespace VariacaoAtivosApi.Tests
{
    public class VariacaoAtivosRepositoryTests
    {
        private readonly VariacaoAtivosRepository _repository;
        private readonly ApplicationDbContext _context;

        public VariacaoAtivosRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new VariacaoAtivosRepository(_context);
        }

        [Fact]
        public async Task ObterPorIdAsync_RetornaVariacaoAtivos_QuandoIdExiste()
        {
            // Arrange
            var id = Guid.NewGuid();
            var variacaoAtivos = new VariacaoAtivos { Id = id, Nome = "Teste" };
            _context.VariacaoAtivos.Add(variacaoAtivos);
            _context.SaveChanges();

            // Act
            var result = await _repository.ObterPorIdAsync(id);

            // Assert
            Assert.Equal(variacaoAtivos, result);
        }

        [Fact]
        public async Task ObterPorIdAsync_RetornaNull_QuandoIdNaoExiste()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await _repository.ObterPorIdAsync(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AdicionarAsync_AdicionaVariacaoAtivos_ERetornaId()
        {
            // Arrange
            var variacaoAtivos = new VariacaoAtivos
            {
                Id = Guid.NewGuid(),
                Nome = "Nome da Variacao",
                Dia = 1,
                Data = DateTime.Now,
                Valor = 10.0m,
                VariacaoD1 = 5.0m,
                VariacaoInicio = 2.0m
            };

            _context.VariacaoAtivos.Add(variacaoAtivos);
            await _context.SaveChangesAsync(); 

            // Act
            var result = await _repository.AdicionarAsync(variacaoAtivos);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            Assert.Contains(variacaoAtivos, _context.VariacaoAtivos);
        }

        [Fact]
        public async Task Exists_RetornaTrue_QuandoVariacaoAtivosExiste()
        {
            // Arrange
            var nome = "Teste";
            var data = DateTime.Now;
            var variacaoAtivos = new VariacaoAtivos { Nome = nome, Data = data };
            _context.VariacaoAtivos.Add(variacaoAtivos);
            _context.SaveChanges();

            // Act
            var result = await _repository.Exists(nome, data);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Exists_RetornaFalse_QuandoVariacaoAtivosNaoExiste()
        {
            // Arrange
            var nome = "Teste";
            var data = DateTime.Now;

            // Act
            var result = await _repository.Exists(nome, data);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task SaveChangesAsync_ChamaSaveChangesNoContexto()
        {
            // Act
            await _repository.SaveChangesAsync();

            // Assert
            Assert.Equal(0, await _context.SaveChangesAsync());
        }
    }
}
