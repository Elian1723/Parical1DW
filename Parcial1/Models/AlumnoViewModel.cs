namespace Parcial1.Models
{
    public class AlumnoViewModel
    {
        public string CarneAlumno { get; set; } = null!;

        public string Nombre1Alumno { get; set; } = null!;

        public string? Nombre2Alumno { get; set; }

        public string Apellido1Alumno { get; set; } = null!;

        public string? Apellido2Alumno { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string DireccionAlumno { get; set; } = null!;

        public string TelefonoAlumno { get; set; } = null!;

        public string CorreoAlumno { get; set; } = null!;

        public string NombreCarrera { get; set; } = null!;
    }
}
