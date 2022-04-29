using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityEquiposProyecto
    {
        public int Codigo_Solicitud { get; set; }
        public string Equipo { get; set; }
        public int Cantidad { get; set; }
        public string Matriz { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public DateTime Fecha_Retorno { get; set; }
    }
}
