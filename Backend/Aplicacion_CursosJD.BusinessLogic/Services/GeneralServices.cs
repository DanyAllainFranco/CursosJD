using Aplicacion_CursosJD.DataAccess.Repository;
using Aplicacion_CursosJD.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_CursosJD.BusinessLogic.Services
{
    public class GeneralServices
    {
        private readonly DepartamentoRepository _departamentosRepository;
        private readonly MunicipioRepository _municipioRepository;
        private readonly EstadoCivilesRepository _estadoCivilesRepository;

        public GeneralServices(DepartamentoRepository departamentosRepository, EstadoCivilesRepository estadoCivilesRepository, MunicipioRepository municipioRepository)
        {
            _departamentosRepository = departamentosRepository;
            _municipioRepository = municipioRepository;
            _estadoCivilesRepository = estadoCivilesRepository;

            
        }

        #region Departamento
        public ServiceResult ListadoDepartamentos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentosRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult ListadoDepartamentosCiudades()
        {
            var result = new ServiceResult();
            try
            {
                var resultados = _departamentosRepository.ListEstadoCiudades();
                var departamentosConCiudades = resultados.Select(r => new tbDepartamentos
                {
                    Dep_Id = r.Dep_Id,
                    Dep_Descripcion = r.Dep_Descripcion,
                    tbMunicipios = r.tbMunicipios.Select(c => new tbMunicipios
                    {
                        Mun_Id = c.Mun_Id,
                        Mun_Descripcion = c.Mun_Descripcion
                    }).ToList()
                });

                return result.Ok(departamentosConCiudades);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }





        public ServiceResult InsertarDepto(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentosRepository.Insert(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



        public ServiceResult ListDepto(string id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentosRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public ServiceResult EditarDepto(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentosRepository.Update(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"Departamento {item.Dep_Id}  {item.Dep_Descripcion}editado con éxito", list);
                }
                else
                {
                    return result.Error("Y existe un registro con ese nombre");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServiceResult EliminarDepto(string Dep_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentosRepository.Delete(Dep_Id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"La accion ha sido existosa", list);
                }
                else
                {
                    return result.Error("No se pudo realizar la accion");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }








        public async Task<ServiceResult> ObtenerDepto()
        {
            try
            {
                var empleados = await _departamentosRepository.ObtenerDepto();
                return new ServiceResult().Ok(empleados);
            }
            catch (Exception ex)
            {
                return new ServiceResult().Error(ex.Message);
            }
        }




        #endregion
        #region EstadoCilvil

        public ServiceResult ListadoEstadoCivil()
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoCivilesRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }





        public ServiceResult InsertarEstadoCivil(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoCivilesRepository.Insert(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



        public ServiceResult ListEstadoCivil(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoCivilesRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public ServiceResult EditarEstadoCivil(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoCivilesRepository.Update(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"editado con éxito", list);
                }
                else
                {
                    return result.Error("Y existe un registro con ese nombre");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServiceResult EliminarEstadoCivil(int EsC_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoCivilesRepository.Delete(EsC_Id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"La accion ha sido existosa", list);
                }
                else
                {
                    return result.Error("No se pudo realizar la accion");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }



        #endregion
        #region Municipio
        public ServiceResult ListadoMunicipio()
        {
            var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }





        public ServiceResult InsertarMunicipio(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.Insert(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



        public ServiceResult ListMunicipio(string id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public ServiceResult EditarMunicipio(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.Update(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"editado con éxito", list);
                }
                else
                {
                    return result.Error("Y existe un registro con ese nombre");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServiceResult EliminarMunicipio(string Mun_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.Delete(Mun_Id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"La accion ha sido existosa", list);
                }
                else
                {
                    return result.Error("No se pudo realizar la accion");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }



        #endregion

    }
}
