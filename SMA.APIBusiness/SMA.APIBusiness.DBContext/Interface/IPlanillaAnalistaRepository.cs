using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMA.APIBusiness.DBContext.Interface
{
    internal interface IPlanillaAnalistaRepository
    {
        EntityBaseResponse GetPlanillaAnalistaRepository();
        EntityBaseResponse ValidarCeseAnalista(int Codigo_Analista);
    }
}
