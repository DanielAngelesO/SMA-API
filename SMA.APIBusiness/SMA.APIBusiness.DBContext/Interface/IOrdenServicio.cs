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
        EntityBaseResponse InsertOrdenServicio(EntityOrdenServicio ordenServicio);
    }
}
