using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanoContas.Domain.Models
{
    public class PlanoContas : EntidadeBase
    {
        public PlanoContas()
        {
        }

        public string Codigo { get; set; }
        public bool AceitaLancamentos { get; set; }
        public int IdPai { get; set; }
        public TipoConta TipoConta { get; set; }

        internal static string ObterPrefixoPai(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return codigo;

            var partes = codigo.Split('.');
            if (partes.Length <= 1)
                return string.Empty;

            return string.Join(".", partes.Take(partes.Length - 1));
        }
    }
} 