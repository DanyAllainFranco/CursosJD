﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Aplicacion_CursosJD.Entities.Entities
{
    public partial class tbDepartamentos
    {
        public tbDepartamentos()
        {
            tbMunicipios = new HashSet<tbMunicipios>();
        }

        public string Dep_Id { get; set; }
        public string Dep_Descripcion { get; set; }
        public int? Dep_UsuarioCreacion { get; set; }
        public DateTime? Dep_FechaCreacion { get; set; }
        public int? Dep_UsuarioModificacion { get; set; }
        public DateTime? Dep_FechaModificacion { get; set; }
        public bool? Dep_Estado { get; set; }

        public virtual tbUsuarios Dep_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Dep_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbMunicipios> tbMunicipios { get; set; }
    }
}