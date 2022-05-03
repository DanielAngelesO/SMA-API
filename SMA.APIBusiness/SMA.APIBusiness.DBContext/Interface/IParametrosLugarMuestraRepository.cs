using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IParametrosLugarMuestraRepository
    {
        EntityBaseResponse ListarPorServicio(int CodigoSolicitud);
        EntityBaseResponse Insert(List<EntityParametrosLugarMuestra> parametros);

 
    }
}
