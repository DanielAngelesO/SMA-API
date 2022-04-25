using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IEquiposProyectoRepository
    {
        EntityBaseResponse GetEquipoProyectoRepository();
        EntityBaseResponse ValidarEquiposProyecto(int Codigo_Equipo, int Codigo_Proyecto);

    }
}