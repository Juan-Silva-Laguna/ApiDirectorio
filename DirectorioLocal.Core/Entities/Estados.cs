using System;
using System.Collections.Generic;

#nullable disable

namespace DirectorioLocal.Core.Entities
{
    public partial class Estados
    {
        public Estados()
        {
            Ciudades = new HashSet<Ciudades>();
        }

        public int Id { get; set; }
        public int IdPais { get; set; }
        public string Name { get; set; }

        public virtual Paises IdPaisNavigation { get; set; }
        public virtual ICollection<Ciudades> Ciudades { get; set; }
    }
}
