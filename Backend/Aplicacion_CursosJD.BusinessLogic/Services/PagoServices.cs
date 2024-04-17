using Aplicacion_CursosJD.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_CursosJD.BusinessLogic.Services
{
    public class PagoServices
    {
        private readonly MetodosPagoRepository _metodosPagoRepository;
        private readonly InfoPago _infoPago;

        public PagoServices(MetodosPagoRepository metodosPagoRepository, InfoPago infoPago)
        {
            _metodosPagoRepository =  metodosPagoRepository;
            _infoPago = infoPago;

        }

        #region Pago
        public ServiceResult ListMetPag()
        {
            var result = new ServiceResult();
            try
            {
                var list = _metodosPagoRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        #endregion

        #region InfoPag
        public ServiceResult ListInfoPag()
        {
            var result = new ServiceResult();
            try
            {
                var list = _infoPago.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        #endregion
    }
}
