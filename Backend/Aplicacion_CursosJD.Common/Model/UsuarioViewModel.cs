using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_CursosJD.Common.Model
{
    public class UsuarioViewModel
    {
        public int Usu_Id { get; set; }
        public string Usu_Usuario { get; set; }
        public string Usu_Contrasena { get; set; }
        public string Usu_Nombre { get; set; }
        public string Usu_Apellido { get; set; }
        public DateTime? Usu_FechaNacimiento { get; set; }
        public string Usu_Sexo { get; set; }
        public string Usu_Direccion { get; set; }
        public string Usu_Telefono { get; set; }
        public string Usu_CorreoElectronico { get; set; }
        public int? Est_Id { get; set; }
        public int? Rol_Id { get; set; }
        public string Mun_Id { get; set; }
        public bool? Usu_Admin { get; set; }
        public int? Usu_UsuarioCreacion { get; set; }
        public DateTime? Usu_FechaCreacion { get; set; }
        public int? Usu_UsuarioModificacion { get; set; }
        public DateTime? Usu_FechaModificacion { get; set; }
        public bool? Usu_Estado { get; set; }
    }
}
