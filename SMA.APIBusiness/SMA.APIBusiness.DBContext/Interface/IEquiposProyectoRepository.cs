using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IEquiposProyectoRepository
    {
        EntityBaseResponse GetEquiposProyecto(int Codigo_Solicitud);
        EntityBaseResponse Insert(List<EntityEquiposProyecto> equipos);
        EntityBaseResponse ActualizarDevolucion(List<EntityEquiposProyecto> equipos);

    }
}
