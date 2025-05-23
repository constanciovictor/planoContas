using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Application.DTOs.PlanoContas.Request
{
    public class PatchPlanoContasRequest
    {
        public string Nome { get; set; } = string.Empty;
        public bool AceitaLancamentos { get; set; }
    }
}
