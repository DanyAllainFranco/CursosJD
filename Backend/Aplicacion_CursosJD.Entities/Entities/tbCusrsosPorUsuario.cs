﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Aplicacion_CursosJD.Entities.Entities
{
    public partial class tbCusrsosPorUsuario
    {
        public int CpU_Id { get; set; }
        public int Usu_Id { get; set; }
        public int Cur_Id { get; set; }
        public int CpU_UsuarioCreacion { get; set; }
        public DateTime CpU_FechaCreacion { get; set; }
        public int? CpU_UsuarioModificacion { get; set; }
        public DateTime? CpU_FechaModificacion { get; set; }
        public bool? CpU_Estado { get; set; }

        public virtual tbUsuarios CpU_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios CpU_UsuarioModificacionNavigation { get; set; }
        public virtual tbCursos Cur { get; set; }
        public virtual tbUsuarios Usu { get; set; }
    }
}