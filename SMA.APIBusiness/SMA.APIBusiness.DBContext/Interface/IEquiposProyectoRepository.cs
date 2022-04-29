using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMA.APIBusiness.DBContext.Interface
{
    internal interface IEquiposProyectoRepository
    {
        EntityBaseResponse GetEquipoProyectoRepository();        

        EntityBaseResponse Insert(List<EntityEquiposProyecto> equipos);
    }
}
