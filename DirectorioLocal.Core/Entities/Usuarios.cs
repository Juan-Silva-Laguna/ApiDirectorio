using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DirectorioLocal.Core.Entities
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public int IdCiudad { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public virtual Ciudades IdCiudadNavigation { get; set; }
    }
}
