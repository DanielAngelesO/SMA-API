using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IPlanillaAnalistaRepository
    {
        EntityBaseResponse GetAnalistas();
        EntityBaseResponse ValidarCeseAnalista(int Codigo_Analista);
    }
}
