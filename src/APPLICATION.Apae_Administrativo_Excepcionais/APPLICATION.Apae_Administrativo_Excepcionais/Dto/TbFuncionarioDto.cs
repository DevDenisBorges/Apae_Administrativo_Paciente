using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPLICATION.Apae_Administrativo_Excepcionais.Dto
{
    public class TbFuncionarioDto
    {
        public int CdFuncionario { get; set; }
        public int CdPessoa { get; set; }
        public string NmLogin { get; set; }
        public string NmSenha { get; set; }
        public int CdTipoFuncionario { get; set; }
    }
}
