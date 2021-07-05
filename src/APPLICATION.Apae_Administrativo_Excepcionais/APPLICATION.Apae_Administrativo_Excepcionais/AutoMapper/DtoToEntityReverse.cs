using APPLICATION.Apae_Administrativo_Excepcionais.Dto;
using AutoMapper;
using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPLICATION.Apae_Administrativo_Excepcionais.AutoMapper
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<TbFuncionario, TbFuncionarioDto>().ReverseMap();
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
