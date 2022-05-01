using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public interface IOrdenServicio
    {
        EntityBaseResponse GetOrdenServicioList();
        EntityBaseResponse GetOrdenServicioList(int CodigoServicio);
        EntityBaseResponse GetOrdenServicioList(string NombreCliente);
        EntityBaseResponse InsertOrdenServicio(EntityOrdenServicio ordenServicio);
        EntityBaseResponse ObtenerProyecto(int CodigoServicio);

    }
}
