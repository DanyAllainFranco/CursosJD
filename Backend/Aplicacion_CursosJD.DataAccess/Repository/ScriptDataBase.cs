using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_CursosJD.DataAccess.Repository
{
    public class ScriptsBaseDeDatos
    {
        #region Departamentos
        public static string Departamento_Insertar = "Gral.sp_Departamentos_insertar";
        public static string Departamento_Listar = "Gral.sp_Departamentos_listar";
        public static string Depa_Llenar = "Gral.sp_Departamentos_buscar";
        public static string Depa_Editar = "Gral.sp_Departamentos_actualizar";
        public static string Depa_Eliminar = "Gral.sp_Departamentos_eliminar";
        public static string Estad_ListaDepartamentoCiudades = "[Gral].[sp_DeparCiudades_listar]";
        #endregion
        #region EstadoCivil
        public static string EstadoCivil_Insertar = "Gral.sp_EstadosCiviles_insertar";
        public static string EstadoCivil_Listar = "Gral.sp_EstadosCiviles_listar";
        public static string EstadoCivil_Llenar = "Gral.sp_EstadosCiviles_buscar";
        public static string EstadoCivil_Editar = "Gral.sp_EstadosCiviles_actualizar";
        public static string EstadoCivil_Eliminar = "Gral.sp_EstadosCiviles_eliminar";
        #endregion
        #region Municipios
        public static string Municipio_Insertar = "Gral.sp_Municipios_insertar";
        public static string Municipio_Listar = "Gral.sp_Municipios_listar";
        public static string Municipio_Llenar = "Gral.sp_Municipios_buscar";
        public static string Municipio_Editar = "Gral.sp_Municipios_actualizar";
        public static string Municipio_Eliminar = "Gral.sp_Municipios_eliminar";
        #endregion
        #region Pantallas
        public static string pantalla_Listar = "Vota.sp_Pantallas_listar";
        #endregion
        #region Roles
        public static string Rol_Listar = "Acce.sp_Roles_listar";
        public static string Rol_Eliminar = "Acce.sp_Roles_eliminar";
        public static string Papro_Buscar = "[Acce].[sp_PantallasPorRol_buscar]";
        public static string Papro_Eliminar = "[Acce].[sp_PantallasPorRol_eliminar]";
        public static string Rol_Obtener = "[Acce].[sp_Roles_obtener]";
        public static string Roles_Actualizar = "[Acce].[sp_Roles_actualizar]";
        public static string Rol_ObtenerId = "Acce.sp_Roles_obtenerid";
        #endregion
        #region Usuarios
        public static string Usuarios_Listar = "Acce.sp_Usuarios_listar";
        public static string Usua_Login = "Acce.sp_Usuarios_iniciosesion1";
        public static string Usua_usuario = "Acce.sp_Usuarios_validarusuario";
        public static string Usua_clave = "Acce.sp_Usuarios_validarclave";
        public static string Usua_Eliminar = "Acce.sp_Usuarios_eliminar";
        public static string Actualizarc = "Acce.sp_Usuarios_Restablecer_Contra";
        public static string Usuario_Llenar = "Gral.sp_Usuario_buscar";
        #endregion
    }
}