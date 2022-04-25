using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IEquipoRepository
    {
        EntityBaseResponse GetEquipoRepository();
        EntityBaseResponse ListEquipoRepository(int Codigo_Equipo);

    }
}