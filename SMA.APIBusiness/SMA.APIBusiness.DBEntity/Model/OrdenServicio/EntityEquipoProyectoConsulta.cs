using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityEquipoProyectoConsulta
    {
        public string Codigo_Equipo { get; set; }
        public string Descripcion_Equipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Estado { get; set; }
        public string Ubicacion { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public int Estado_Devolucion { get; set; }


    }
}
