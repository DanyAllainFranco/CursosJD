using Aplicacion_CursosJD.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_CursosJD.BusinessLogic.Services
{
    public class CursoServices
    {
        private readonly CategoriaRepository _categoriaRepository;
        private readonly CursoRepository _cursoRepository;
        private readonly CursosPorUsuarioRepository _cursosPorUsuarioRepository;
        private readonly  InstructorPorCursoRepository _instructorPorCursoRepository;
        private readonly InstructorRepository _instructorRepository;
        private readonly RecursosRepository _recursosRepository;



        public CursoServices(CategoriaRepository categoriaRepository, CursoRepository cursoRepository, CursosPorUsuarioRepository cursosPorUsuarioRepository, InstructorPorCursoRepository instructorPorCursoRepository, InstructorRepository  instructorRepository, RecursosRepository recursosRepository)
        {
            _categoriaRepository = categoriaRepository;
            _cursoRepository = cursoRepository;
            _cursosPorUsuarioRepository =  cursosPorUsuarioRepository;
            _instructorPorCursoRepository = instructorPorCursoRepository;
            _instructorRepository =  instructorRepository;
            _recursosRepository =  recursosRepository;
        }
    }
}
