using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface ILugaresMuestreoRepository
    {
        EntityBaseResponse GetLugaresMuestreoRepository();
        EntityBaseResponse ListLugarProyecto(int Codigo_Cliente);

    }
}