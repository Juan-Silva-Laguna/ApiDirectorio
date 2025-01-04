using System;
using System.Collections.Generic;

#nullable disable

namespace DirectorioLocal.Core.Entities
{
    public partial class Ciudades
    {
        public Ciudades()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public int IdEstado { get; set; }
        public string Name { get; set; }

        public virtual Estados IdEstadoNavigation { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
