using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityLoginResponse
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }        
        public string Perfil { get; set; }
        public string Token { get; set; }

    }
}
