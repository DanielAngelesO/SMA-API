using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityOrdenServicio: EntityBase
    {
        public int Codigo_Solicitud { get; set; }
        public DateTime Fecha_Solicitud { get; set; }
        public DateTime Fecha_Tentativa { get; set; }
        public string Usuario_Registro { get; set; }
        public string Estado_Solicitud { get; set; }
        public string Cod_Servicio { get; set; }

        public EntityCliente Cliente { get; set; }
        public List<EntityLugaresMuestreo> LugaresMuestreo { get; set; }


    }
}
