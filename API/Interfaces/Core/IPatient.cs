using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Core
{
    public interface IPatient
    {
        Task InsertNewPatient(Persona newPerson, Paciente entityInsert);
        Task<List<Persona>> GetAllPatients();
        Task<List<Paciente>> GetAll();
    }
}
