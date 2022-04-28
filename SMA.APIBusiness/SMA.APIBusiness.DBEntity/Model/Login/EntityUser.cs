using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Contrasenia { get; set; }
        public string Perfil { get; set; }        
    }
}
