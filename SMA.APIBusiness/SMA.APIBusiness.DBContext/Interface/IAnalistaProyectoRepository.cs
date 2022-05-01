using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IAnalistaProyectoRepository
    {
        EntityBaseResponse ObtenerAnalistas(int Codigo_Solicitud);

        EntityBaseResponse Insert(List<EntityAnalistaProyecto> Analistas);
    }
}
