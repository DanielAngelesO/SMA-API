﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityAnalistaProyecto
    {
        public int Codigo_Cliente { get; set; }
        public int Codigo_Analista { get; set; }
        public string Cargo { get; set; }
        public string Tarea_Asignada { get; set; }
    }
}
