using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Persona
    {
        public Persona()
        {
            PacienteNmidMedicotraNavigations = new HashSet<Paciente>();
            PacienteNmidPersonaNavigations = new HashSet<Paciente>();
        }

        public int Nmid { get; set; }
        public string Cddocumento { get; set; }
        public string Dsnombres { get; set; }
        public string Dsapellidos { get; set; }
        public DateTime? Fenacimiento { get; set; }
        public int Cdtipo { get; set; }
        public int? Cdgenero { get; set; }
        public DateTime? Feregistro { get; set; }
        public DateTime? Febaja { get; set; }
        public string Cdusuario { get; set; }
        public string Dsdireccion { get; set; }
        public string Dsphoto { get; set; }
        public string CdtelfonoFijo { get; set; }
        public string CdtelefonoMovil { get; set; }
        public string DsEmail { get; set; }

        public virtual Genero CdgeneroNavigation { get; set; }
        public virtual TiposPersona CdtipoNavigation { get; set; }
        public virtual ICollection<Paciente> PacienteNmidMedicotraNavigations { get; set; }
        public virtual ICollection<Paciente> PacienteNmidPersonaNavigations { get; set; }
    }
}
