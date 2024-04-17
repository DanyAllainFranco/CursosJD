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
    public class MetodosPagoRepository
    {
        public IEnumerable<tbMetodosPagos> List()
        {
            const string sql = "[Pago].[sp_MetodosPagos_listar]";

            List<tbMetodosPagos> result = new List<tbMetodosPagos>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                result = db.Query<tbMetodosPagos>(sql, commandType: CommandType.Text).ToList();
                return result;
            }
            //throw new NotImplementedException();
        }
    }
}
