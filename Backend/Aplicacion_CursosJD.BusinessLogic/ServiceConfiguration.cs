using Microsoft.Extensions.DependencyInjection;
using Aplicacion_CursosJD.DataAccess;
using Aplicacion_CursosJD.BusinessLogic.Services;
using System;

namespace Aplicacion_CursosJD.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection service, string conn)
        {
            Aplicacion_CursosJDContext.BuildConnectionString(conn);
        }
        public static void BusinessLogic(this IServiceCollection service)
        {
           
        }
    }
}
