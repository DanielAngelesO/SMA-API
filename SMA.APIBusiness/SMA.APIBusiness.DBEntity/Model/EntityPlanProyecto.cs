using System;
using System.Collections.Generic;
using System.Text;

namespace SMA.APIBusiness.DBEntity.Model
{
    internal class EntityPlanProyecto
    {
        public int Codigo_Cliente { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public int Dias_Monitoreo { get; set; }
        public int Cantidad_Analista { get; set; }
        public decimal Monto_Viaticos { get; set; }
        public decimal Precio_Final_Servicio { get; set; }
    }
}
