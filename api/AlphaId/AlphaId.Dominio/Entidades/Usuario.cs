using AlphaId.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaId.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }

        public string Area { get; set; }

        public string Cpf { get; set; }

        public string Senha { get; set; }

        public string epi { get; set; }

        public string quantiidade { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
    }
}
