using Microsoft.EntityFrameworkCore;
using VariacaoAtivoApi.DTOs;
using VariacaoAtivoApi.Models;
using VariacaoAtivoApi.Repositories;

namespace VariacaoAtivoApi.Services
{
    public class VariacaoAtivosService : IVariacaoAtivosService
    {
        private readonly IVariacaoAtivosRepository _variacaoAtivosRepository;
        public VariacaoAtivosService(IVariacaoAtivosRepository variacaoAtivosRepository)
        {
            _variacaoAtivosRepository = variacaoAtivosRepository;
        }

        public async Task<List<VariacaoAtivos>> ConvertToVariacaoAtivosList(AtivosResponseDto adto)
        {
            var numeroPregoes = adto.Chart.Result[0].Indicators.Quote[0].Open.Count();
            decimal pregaoInicial = adto.Chart.Result[0].Indicators.Quote[0].Open[0];
            List<VariacaoAtivos> responseAtivos = new List<VariacaoAtivos>();

            for (int i = 0; i < numeroPregoes; i++)
            {
                decimal valorAtual = adto.Chart.Result[0].Indicators.Quote[0].Open[i];
                decimal valorAnterior = i > 0 ? adto.Chart.Result[0].Indicators.Quote[0].Open[i - 1] : pregaoInicial;

                var ativo = new VariacaoAtivos
                {
                    Id = Guid.NewGuid(),
                    Nome = adto.Chart.Result[0].Meta.Symbol,
                    Dia = DateTimeOffset.FromUnixTimeSeconds(adto.Chart.Result[0].Timestamp[i]).UtcDateTime.Day,
                    Data = DateTimeOffset.FromUnixTimeSeconds(adto.Chart.Result[0].Timestamp[i]).UtcDateTime,
                    Valor = adto.Chart.Result[0].Indicators.Quote[0].Open[i],
                    VariacaoD1 = i > 0 ? ((valorAtual - valorAnterior) / valorAnterior) * 100 : 0,
                    VariacaoInicio = i > 0 ? ((valorAtual - pregaoInicial) / pregaoInicial) * 100 : 0
                };

                responseAtivos.Add(ativo);
            }

            return responseAtivos;
        }

        public async Task SaveVariacoesAtivosIfNotExists(List<VariacaoAtivos> variacoesAtivos)
        {
            foreach (var variacao in variacoesAtivos)
            {
                try
                {
                    if (!await _variacaoAtivosRepository.Exists(variacao.Nome, variacao.Data))
                    {
                        await _variacaoAtivosRepository.AdicionarAsync(variacao);
                    }
                }
                catch (Exception ex)
                {
                    throw new HttpRequestException($"Erro ao persistir dado: {ex.Message}");
                }
                
            }
            await _variacaoAtivosRepository.SaveChangesAsync();
        }
    }
}
