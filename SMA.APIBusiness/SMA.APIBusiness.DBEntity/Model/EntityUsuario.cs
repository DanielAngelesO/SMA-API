using System;
using System.Collections.Generic;
using System.Text;


namespace DBEntity
{
    public class EntityUsuario: EntityBase
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Perfil { get; set; }

    }
}
