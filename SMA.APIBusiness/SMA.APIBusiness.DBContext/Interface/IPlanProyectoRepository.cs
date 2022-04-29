using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IPlanProyectoRepository
    {
        EntityBaseResponse GetPlanProyectoRepository();
        EntityBaseResponse insert(EntityPlanProyecto plan);

    }
}
