using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class TiposPersona
    {
        public TiposPersona()
        {
            Personas = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
