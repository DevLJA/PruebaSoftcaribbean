using Data.Implementation.Generic;
using Interfaces.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class PatientData : DataGenericCRUD<Paciente>
    {
    }
    public class PersonData : DataGenericCRUD<Persona>
    {
    }
    public class PersonTypeData : DataGenericCRUD<TiposPersona>
    {
    }
    public class GendersData : DataGenericCRUD<Genero>
    {
    }
}
