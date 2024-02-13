namespace VariacaoAtivoApi.DTOs
{
    public class ConsultarAtivoQueryDto
    {
        public string Nome { get; set; }
        public string Intervalo { get; set; }
        public string Prazo { get; set; }

        public ConsultarAtivoQueryDto(string nome)
        {
            Nome = nome;
            Intervalo = "1d";
            Prazo = "30d";
        }

        public ConsultarAtivoQueryDto(string nome, string intevalo, string dias)
        {
            Nome = nome;
            Intervalo = intevalo;
            Prazo = dias;
        }
    }
}
