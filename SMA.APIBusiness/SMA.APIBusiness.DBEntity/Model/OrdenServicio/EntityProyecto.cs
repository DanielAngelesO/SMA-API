using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProyecto
    {
        public string Codigo_Solicitud { get; set; }
        public string Ruc_Cliente { get; set; }
        public string Razon_Social { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public string Codigo_Servicio { get; set; }
        public string Descripcion_Servicio { get; set; }
        public string TipoServicio { get; set; }
        public decimal Precio_Referencia { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public int Dias_Monitoreo { get; set; }
        public int Cantidad_Analistas { get; set; }
        public decimal Monto_Viaticos { get; set; }
        public decimal Precio_Final_Servicio { get; set; }
        public string Estado_Solicitud { get; set; }
        public string Usuario_Registro { get; set; }
        public DateTime Fecha_Solicitud { get; set; }

        public List<EntityLugaresMuestreoConsulta> LugaresMuestreo { get; set; }
        public List<EntityAnalistaProyectoConsulta> Analistas { get; set; }
        public List<EntityEquipoProyectoConsulta> Equipos { get; set; }


    }
}
