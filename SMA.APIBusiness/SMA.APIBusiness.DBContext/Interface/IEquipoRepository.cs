using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IEquipoRepository
    {
        EntityBaseResponse ListarEquipos();
        EntityBaseResponse ListarEquipos(string Codigo_Equipo);
        EntityBaseResponse ListarEquiposOperativos();




    }
}
