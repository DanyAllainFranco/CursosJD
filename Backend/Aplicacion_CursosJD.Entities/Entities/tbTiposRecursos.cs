﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Aplicacion_CursosJD.Entities.Entities
{
    public partial class tbTiposRecursos
    {
        public tbTiposRecursos()
        {
            tbRecursos = new HashSet<tbRecursos>();
        }

        public int TpR_Id { get; set; }
        public string TpR_Descripcion { get; set; }
        public int TpR_UsuarioCreacion { get; set; }
        public DateTime TpR_FechaCreacion { get; set; }
        public int? TpR_UsuarioModificacion { get; set; }
        public DateTime? TpR_FechaModificacion { get; set; }
        public bool? TpR_Estado { get; set; }

        public virtual tbUsuarios TpR_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios TpR_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbRecursos> tbRecursos { get; set; }
    }
}