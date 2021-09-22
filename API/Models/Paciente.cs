using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Paciente
    {
        public int Nmid { get; set; }
        public int NmidPersona { get; set; }
        public int NmidMedicotra { get; set; }
        public string Dseps { get; set; }
        public string Dsarl { get; set; }
        public DateTime? Feregistro { get; set; }
        public DateTime? Febaja { get; set; }
        public string Cdusuario { get; set; }
        public string Dscondicion { get; set; }

        public virtual Persona NmidMedicotraNavigation { get; set; }
        public virtual Persona NmidPersonaNavigation { get; set; }
    }
}
