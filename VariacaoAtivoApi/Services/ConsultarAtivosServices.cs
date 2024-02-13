using System.Text.Json;
using System.Net.Http;
using VariacaoAtivoApi.DTOs;
using VariacaoAtivoApi.Models;

namespace VariacaoAtivoApi.Services
{
    public class ConsultarAtivosServices : IConsultarAtivosServices
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly IVariacaoAtivosService _variacaoAtivosService;

        public ConsultarAtivosServices(IVariacaoAtivosService variacaoAtivosService)
        {
            _variacaoAtivosService = variacaoAtivosService;
        }

        public async Task<List<VariacaoAtivos>> ConsultarAtivo(ConsultarAtivoQueryDto consultaAtivo)
        {

            try
            {
                var ativoUrl = $"https://query2.finance.yahoo.com/v8/finance/chart/{consultaAtivo.Nome}?interval={consultaAtivo.Intervalo}&range={consultaAtivo.Prazo}";

                HttpResponseMessage ativoResponse = await client.GetAsync(ativoUrl);

                if (ativoResponse.IsSuccessStatusCode)
                {
                    string responseContent = await ativoResponse.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    AtivosResponseDto ativosResponseDto = JsonSerializer.Deserialize<AtivosResponseDto>(responseContent, options);

                    var listAtivos = await _variacaoAtivosService.ConvertToVariacaoAtivosList(ativosResponseDto);

                    await _variacaoAtivosService.SaveVariacoesAtivosIfNotExists(listAtivos);

                    return listAtivos;
                }
                else
                {
                    throw new HttpRequestException($"Erro na requisição HTTP: {ativoResponse.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar o ativo.", ex);
            }
        }
    }
}
