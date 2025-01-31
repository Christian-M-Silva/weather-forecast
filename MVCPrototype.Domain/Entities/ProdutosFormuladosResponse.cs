using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MVCPrototype.Domain.Entities
{
    public class ProdutosFormuladosResponse
    {
        public required List<string> MarcaComercial { get; set; }

        public string? Formulacao { get; set; }

        public required List<string> TecnicaAplicacao { get; set; }

        public required string ClassificacaoToxicologica { get; set; }

        public required string ClassificacaoAmbiental { get; set; }

    }
}
