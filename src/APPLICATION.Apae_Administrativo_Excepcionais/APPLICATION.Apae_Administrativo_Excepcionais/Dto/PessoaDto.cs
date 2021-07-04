using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPLICATION.Apae_Administrativo_Excepcionais.Dto
{
    public class TbPessoaDto
    {
        public int CdPessoa { get; set; }
        public string NmNomeCompleto { get; set; }
        public string NmTelefone { get; set; }
        public decimal? NrCpf { get; set; }
    }
}
