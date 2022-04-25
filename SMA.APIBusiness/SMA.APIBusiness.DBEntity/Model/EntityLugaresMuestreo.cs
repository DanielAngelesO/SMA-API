using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityLugaresMuestreo
    {
        public int Codigo_Cliente { get; set; }
        public int Cod_Orden { get; set; }
        public string Lugar_Muestreo { get; set; }
        public string Coordenada_Longitud { get; set; }
        public string Coordenada_Latitud { get; set; }
        public string Nombre_Punto { get; set; }
    }
}
