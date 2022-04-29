using System;
using System.Collections.Generic;
using System.Text;

namespace SMA.APIBusiness.DBEntity.Model
{
    internal class EntityLugarsMuestro
    {
        public int CodigoMuestreo { get; set; }
        public int CodigoSolicitud { get; set; }
        public string LugarMuestro { get; set; }
        public string Lontigitud { get; set; }
        public string Latitud { get; set; }
        public string NombrePunto { get; set; }
    }
}
