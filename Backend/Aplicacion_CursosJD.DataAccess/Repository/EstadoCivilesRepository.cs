using Aplicacion_CursosJD.BusinessLogic.Services;
using Aplicacion_CursosJD.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_CursosJD.DataAccess.Repository
{
    public class EstadoCivilesRepository : IRepository<tbEstadosCiviles>
    {
        public RequestStatus Insert(tbEstadosCiviles item)
        {
            const string sql = "Gral.sp_EstadosCiviles_insertar";



            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@EsC_Descripcion", item.Est_Descripcion);
                parametro.Add("@EsC_UsuarioCreacion ", item.Est_UsuarioCreacion);
                parametro.Add("@EsC_FechaCreacion", item.Est_FechaCreacion);



                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }

        public IEnumerable<tbEstadosCiviles> List()
        {
            const string sql = "Gral.sp_EstadosCiviles_listar";

            List<tbEstadosCiviles> result = new List<tbEstadosCiviles>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                result = db.Query<tbEstadosCiviles>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public tbEstadosCiviles List(int id)
        {

            tbEstadosCiviles result = new tbEstadosCiviles();
            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("EsC_Id", id);
                result = db.QueryFirst<tbEstadosCiviles>(ScriptsBaseDeDatos.EstadoCivil_Llenar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }

        }



        public tbEstadosCiviles Details(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int EsC_Id)
        {
            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("EsC_Id", EsC_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.EstadoCivil_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }

        public RequestStatus Delete(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }


     



        public RequestStatus Update(tbEstadosCiviles item)
        {


            string sql = ScriptsBaseDeDatos.EstadoCivil_Editar;

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@EsC_Id", item.Est_Id);
                parameter.Add("@EsC_Descripcion", item.Est_Descripcion);
                parameter.Add("@EsC_UsuarioModificacion ", item.Est_UsuarioModificacion);
                parameter.Add("@EsC_FechaModificacion ", item.Est_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }





        }

        public tbEstadosCiviles find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
