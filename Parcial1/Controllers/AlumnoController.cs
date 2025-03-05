using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcial1.Data.Context;
using Parcial1.Data.Models;
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
            var alumnos = _context.Alumnos
                .Select(alumno => new AlumnoViewModel
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
                }).ToList();

            return alumnos;
        }

        public IActionResult BuscarAlumno(string carne)
        {
            Alumno? alumnoEncontrado = null;

            if (!string.IsNullOrEmpty(carne))
            {
                alumnoEncontrado = _context.Alumnos.Where(p => p.CarneAlumno == carne).FirstOrDefault();
            }

            var carreras = _context.Carreras
                .Select(carrera => new SelectListItem
                {
                    Value = carrera.CodigoCarrera.ToString(),
                    Text = carrera.NombreCarrera
                });

            ViewBag.Carreras = carreras.ToList();

            return View("CrudAlumno", alumnoEncontrado);
        }

        public IActionResult CrearAlumno(Alumno nuevoAlumno)
        {
            if (ModelState.IsValid == false)
            {
                return View("CrudAlumno", null);
            }

            _context.Alumnos.Add(nuevoAlumno);

            _context.SaveChanges();

            return View("Index", ObtenerAlumnos());
        }

        public IActionResult EditarAlumno(Alumno alumnoEditado)
        {
            if (ModelState.IsValid == false)
            {
                return View("CrudAlumno", alumnoEditado);
            }

            var alumno = _context.Alumnos.Find(alumnoEditado.CarneAlumno);

            if (alumno != null)
            {
                alumno.Nombre1Alumno = alumnoEditado.Nombre1Alumno;
                alumno.Nombre2Alumno = alumnoEditado.Nombre2Alumno;
                alumno.Apellido1Alumno = alumnoEditado.Apellido1Alumno;
                alumno.Apellido2Alumno = alumnoEditado.Apellido2Alumno;
                alumno.FechaNacimiento = alumnoEditado.FechaNacimiento;
                alumno.DireccionAlumno = alumnoEditado.DireccionAlumno;
                alumno.TelefonoAlumno = alumnoEditado.TelefonoAlumno;
                alumno.CorreoAlumno = alumnoEditado.CorreoAlumno;
                alumno.CodigoCarrera = alumnoEditado.CodigoCarrera;

                _context.SaveChanges();
            }

            return View("Index", ObtenerAlumnos());
        }

        public IActionResult EliminarAlumno(Alumno alumnoEliminado)
        {
            var alumno = _context.Alumnos.Find(alumnoEliminado.CarneAlumno);

            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);

                _context.SaveChanges();
            }

            return View("Index", ObtenerAlumnos());
        }
    }
}
