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
    public class InfoPago
    {
        public IEnumerable<tbInfoPagos> List()
        {
            const string sql = "[Pago].[sp_InfoPago_listar]";

            List<tbInfoPagos> result = new List<tbInfoPagos>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                result = db.Query<tbInfoPagos>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }
    }
}
