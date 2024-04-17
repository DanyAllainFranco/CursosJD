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
    public class CursosPorUsuarioRepository
    {
        public IEnumerable<tbCusrsosPorUsuario> List()
        {
            const string sql = "[Curs].[sp_CursosPorUsuario_listar]";

            List<tbCusrsosPorUsuario> result = new List<tbCusrsosPorUsuario>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                result = db.Query<tbCusrsosPorUsuario>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }
    }
}
