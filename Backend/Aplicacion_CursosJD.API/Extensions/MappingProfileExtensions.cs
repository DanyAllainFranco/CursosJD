using AutoMapper;
using Aplicacion_CursosJD.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion_CursosJD.BusinessLogic.Services;
using Aplicacion_CursosJD.Common.Model;

namespace Aplicacion_CursosJD.API.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<DepartamentoViewModel, tbDepartamentos>().ReverseMap();
            CreateMap<UsuarioViewModel, tbUsuarios>().ReverseMap();
        }
    }
}
