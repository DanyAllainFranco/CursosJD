using Aplicacion_CursosJD.BusinessLogic.Services;
using Aplicacion_CursosJD.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Aplicacion_CursosJD.Common.Model;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_CursosJD.DataAccess.Repository
{
    public class UsuarioRepository
    {
        public IEnumerable<UsuarioViewModel> List()
        {
            const string sql = "Acce.sp_Usuarios_listar";

            List<UsuarioViewModel> result = new List<UsuarioViewModel>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                result = db.Query<UsuarioViewModel>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }





        public IEnumerable<tbUsuarios> Login(string Usuario, string Contra)
        {
            string sql = ScriptsBaseDeDatos.Usua_Login;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameters = new { @Usuario = Usuario, @Contra = Contra };
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbUsuarios> ValidarUsuario(string Usuario)
        {
            string sql = ScriptsBaseDeDatos.Usua_usuario;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameters = new { @Usuario = Usuario };
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbUsuarios> ValidarClave(string Contra)
        {
            string sql = ScriptsBaseDeDatos.Usua_clave;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameters = new { @Contra = Contra };
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }





        public RequestStatus Insert(tbUsuarios item)
        {
            const string sql = "Acce.sp_Usuarios_insertar";



            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Usuar_Usuario", item.Usu_Usuario);
                parametro.Add("@Usuar_Contrasena ", item.Usu_Contrasena);
                parametro.Add("@Usu_Nombre", item.Usu_Nombre);
                parametro.Add("@Usu_Apellido", item.Usu_Apellido);
                parametro.Add("@Usu_FechaNacimiento", item.Usu_FechaNacimiento);
                parametro.Add("@Usu_Sexo", item.Usu_Sexo);
                parametro.Add("@Usu_Direccion", item.Usu_Direccion);
                parametro.Add("@Usu_Telefono", item.Usu_Telefono);
                parametro.Add("@Usu_CorreoElectronico", item.Usu_CorreoElectronico);
                parametro.Add("@Est_Id", item.Est_Id);
                parametro.Add("@Mun_Id", item.Mun_Id);
                parametro.Add("@Roles_Id", item.Rol_Id);
                parametro.Add("@Usuar_Admin", item.Usu_Admin);
                parametro.Add("@Usuar_UsuarioCreacion", 1);
                parametro.Add("@Usuar_FechaCreacion", item.Usu_FechaCreacion);





                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }

        public tbUsuarios Details(int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int Usuar_Id)
        {
            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Usuar_Id", Usuar_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.Usua_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }

        public RequestStatus Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }


        public tbDepartamentos find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus UpdateC(tbUsuarios item)
        {


            string sql = ScriptsBaseDeDatos.Actualizarc;

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Usuar_Id", item.Usu_Id);
                parameter.Add("@Usuar_Contrasena", item.Usu_Contrasena);


                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }



        }
        public RequestStatus UpdateU(tbUsuarios item)
        {


            string sql = ScriptsBaseDeDatos.Actualizarc;

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Usuar_Id", item.Usu_Id);
                parametro.Add("@Usu_Nombre", item.Usu_Nombre);
                parametro.Add("@Usu_Apellido", item.Usu_Apellido);
                parametro.Add("@Usu_FechaNacimiento", item.Usu_FechaNacimiento);
                parametro.Add("@Usu_Sexo", item.Usu_Sexo);
                parametro.Add("@Usu_Direccion", item.Usu_Direccion);
                parametro.Add("@Usu_Telefono", item.Usu_Telefono);
                parametro.Add("@Usu_CorreoElectronico", item.Usu_CorreoElectronico);
                parametro.Add("@Est_Id", item.Est_Id);
                parametro.Add("@Mun_Id", item.Mun_Id);
                parametro.Add("@Roles_Id", item.Rol_Id);
                parametro.Add("@Usuar_Admin", item.Usu_Admin);
                parametro.Add("@Usuar_UsuarioCreacion", 1);
                parametro.Add("@Usuar_FechaCreacion", item.Usu_FechaCreacion);

                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }



        }
        public tbUsuarios List(int id)
        {

            tbUsuarios result = new tbUsuarios();
            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Usuar_Id", id);
                result = db.QueryFirst<tbUsuarios>(ScriptsBaseDeDatos.Usuario_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }

        }
    }
}
