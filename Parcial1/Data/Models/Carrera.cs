namespace Parcial1.Data.Models;

public partial class Carrera
{
    public int CodigoCarrera { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
