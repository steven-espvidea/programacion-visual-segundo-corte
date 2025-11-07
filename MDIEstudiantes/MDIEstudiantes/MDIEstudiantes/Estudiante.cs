using System.Collections.Generic;
using System.Linq;

namespace MDIEstudiantes
{
    public class Estudiante
    {
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();

        public double Promedio
        {
            get
            {
                if (Asignaturas == null || Asignaturas.Count == 0) return 0;
                return Asignaturas.Average(a => a.Nota);
            }
        }
    }

    public class Asignatura
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }
    }

    public static class DatosCompartidos
    {
        // Ahora guardamos varios estudiantes
        public static List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    }
}
