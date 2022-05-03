using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IParametrosLugarMuestraRepository
    {
        EntityBaseResponse ListarLugaresMuestreo(string Cod_Orden);

        EntityBaseResponse ObtenerLugaresMuestreo();
 
    }
}
