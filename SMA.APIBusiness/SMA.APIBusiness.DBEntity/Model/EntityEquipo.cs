using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityEquipo
    {
        public int Codigo_Cliente { get; set; }
        public string Descripcion_Equipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Estado { get; set; }
        public string Ubicado { get; set; }
    }
}
