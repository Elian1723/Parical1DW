using Microsoft.AspNetCore.Mvc;
using Parcial1.Data.Context;
using Parcial1.Models;

namespace Parcial1.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly Parcial1_DWContext _context;

        public AlumnoController(Parcial1_DWContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View(ObtenerAlumnos());
        }

        public List<AlumnoViewModel> ObtenerAlumnos()
        {
            var alumnos = new List<AlumnoViewModel>();

            foreach (var alumno in _context.Alumnos)
            {
                var alumnoViewModel = new AlumnoViewModel
                {
                    CarneAlumno = alumno.CarneAlumno,
                    Nombre1Alumno = alumno.Nombre1Alumno,
                    Nombre2Alumno = alumno.Nombre2Alumno,
                    Apellido1Alumno = alumno.Apellido1Alumno,
                    Apellido2Alumno = alumno.Apellido2Alumno,
                    FechaNacimiento = alumno.FechaNacimiento,
                    DireccionAlumno = alumno.DireccionAlumno,
                    TelefonoAlumno = alumno.TelefonoAlumno,
                    CorreoAlumno = alumno.CorreoAlumno,
                    NombreCarrera = alumno.CodigoCarreraNavigation.NombreCarrera
                };

                alumnos.Add(alumnoViewModel);
            }

            return alumnos;
        }
    }
}
