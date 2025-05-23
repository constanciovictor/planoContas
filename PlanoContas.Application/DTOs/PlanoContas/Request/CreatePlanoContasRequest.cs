namespace PlanoContas.Application.DTOs.PlanoContas.Request
{
    public class CreatePlanoContasRequest
    {
        public string Codigo { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public int TipoContaId { get; set; }

        public bool AceitaLancamentos { get; set; }

        public int? IdPai { get; set; }
    }
}
