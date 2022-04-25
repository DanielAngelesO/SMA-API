using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class EquiposProyectoRepository : BaseRepository, IEquiposProyectoRepository
    {
        public EntityBaseResponse GetEquipoProyectoRepository()
        {
            throw new NotImplementedException();
        }

        public EntityBaseResponse ValidarEquiposProyecto(int Codigo_Equipo, int Codigo_Proyecto)
        {
            throw new NotImplementedException();
        }
    }
}
