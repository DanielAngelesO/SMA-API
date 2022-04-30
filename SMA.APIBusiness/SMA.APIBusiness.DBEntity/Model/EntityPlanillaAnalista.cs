using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityPlanillaAnalista
    {
        public string Codigo_Analista { get; set; }
        public string Nombre_Analista { get; set; }
        public string Tipo { get; set; }
        public string Grado_Instruccion { get; set; }
        public string Especialidad { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public DateTime Fecha_Cese { get; set; }
    }
}
