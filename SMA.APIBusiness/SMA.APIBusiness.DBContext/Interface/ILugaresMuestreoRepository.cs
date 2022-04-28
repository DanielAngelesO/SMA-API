using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMA.APIBusiness.DBContext.Interface
{
    internal interface ILugaresMuestreoRepository
    {
        EntityBaseResponse GetLugaresMuestreoRepository();
        EntityBaseResponse ListLugarProyecto(int Codigo_Cliente);
    }
}
