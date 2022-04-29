using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMA.APIBusiness.DBContext.Interface
{
    internal interface IAnalistaProyectoRepository
    {
        EntityBaseResponse GetAnalistaProyectoRepository();
        EntityBaseResponse ObtenerAnalista(string Codigo_Analista);

        EntityBaseResponse Insert(List<EntityAnalistaProyecto> Analistas);
    }
}
