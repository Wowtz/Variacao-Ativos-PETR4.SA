using System.Text.Json.Serialization;

namespace VariacaoAtivoApi.Models
{
    public class VariacaoAtivos
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("Dia")]
        public int Dia { get; set; }

        [JsonPropertyName("Data")]
        public DateTime Data { get; set; }

        [JsonPropertyName("Valor")]
        public decimal Valor { get; set; }

        [JsonPropertyName("VariacaoD1")]
        public decimal VariacaoD1 { get; set; }

        [JsonPropertyName("VariacaoInicio")]
        public decimal VariacaoInicio { get; set; }
    }
}
