using System;
using System.Collections.Generic;

#nullable disable

namespace DirectorioLocal.Core.Entities
{
    public partial class Paises
    {
        public Paises()
        {
            Estados = new HashSet<Estados>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Estados> Estados { get; set; }
    }
}
