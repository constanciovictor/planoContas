namespace PlanoContas.Application.DTOs.PlanoContas.Response
{
    public class GetPlanoContasResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public bool AceitaLancamentos { get; set; }
        public int IdPai { get; set; }
    }
}
