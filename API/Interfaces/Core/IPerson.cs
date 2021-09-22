using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Core
{
    public interface IPerson
    {
        Task InsertNewPerson(Persona entityInsert);
        Task UpdatePerson(Persona entityUpdate);
        Task<List<Persona>> GetAll();
        Task<List<Persona>> GetAllMedical();
    }
}
