﻿using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMA.APIBusiness.DBContext.Interface
{
    internal interface IEquipoRepository
    {
        EntityBaseResponse ListarEquipos();
        EntityBaseResponse ListEquipoRepository(int Codigo_Equipo);
    }
}