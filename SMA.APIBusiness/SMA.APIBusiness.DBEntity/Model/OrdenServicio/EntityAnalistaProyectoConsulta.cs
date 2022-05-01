using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityAnalistaProyectoConsulta
    {
        public int Codigo_Solicitud { get; set; }
        public string Nombre_Analista { get; set; }
        public string Cargo { get; set; }
        public string Tarea_Asignada { get; set; }
        public string Tipo { get; set; }
        public string Grado_Instruccion { get; set; }
        public string Especialidad { get; set; }
    }
}
