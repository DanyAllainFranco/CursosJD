using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Aplicacion_CursosJD.DataAccess.Context;
using System;

namespace Aplicacion_CursosJD.DataAccess
{
    public class Aplicacion_CursosJDContext : Udemy_JasondanyContext
    {
        public static string ConnectionString { get; set; }

        public Aplicacion_CursosJDContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public static void BuildConnectionString(string connection)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder { ConnectionString = connection };
            ConnectionString = connectionStringBuilder.ConnectionString;
        }
    }
}
