﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Entities
{
    public partial class TbPessoa
    {
        public TbPessoa()
        {
            TbFuncionario = new HashSet<TbFuncionario>();
        }

        public int CdPessoa { get; set; }
        public string NmNomeCompleto { get; set; }
        public string NmTelefone { get; set; }
        public decimal NrCpf { get; set; }

        public virtual ICollection<TbFuncionario> TbFuncionario { get; set; }
    }
}