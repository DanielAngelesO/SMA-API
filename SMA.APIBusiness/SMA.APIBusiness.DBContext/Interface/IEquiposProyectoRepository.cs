using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IEquiposProyectoRepository
    {
        EntityBaseResponse GetEquipoProyectoRepository(string Codigo_Solicitud);        

        EntityBaseResponse Insert(List<EntityEquiposProyecto> equipos);
    }
}
