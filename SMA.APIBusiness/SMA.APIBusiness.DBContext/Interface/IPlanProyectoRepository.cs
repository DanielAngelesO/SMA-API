using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMA.APIBusiness.DBContext.Interface
{
    internal interface IPlanProyectoRepository
    {
        EntityBaseResponse GetPlanProyectoRepository();
        EntityBaseResponse insert(EntityPlanProyecto plan);

    }
}
