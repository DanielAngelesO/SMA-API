using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface ILugaresMuestreoRepository
    {
        EntityBaseResponse GetLugaresMuestreoRepository(int Cod_Orden);
        
        EntityBaseResponse Insert(List<EntityLugaresMuestreo> muestreos);
        EntityBaseResponse Insert(int Codigo_Solcitud, List<EntityLugaresMuestreo> muestreos);
    }
}

