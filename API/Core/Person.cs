using Core.Utils;
using Data.Implementation;
using Interfaces.Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Person : IPerson
    {
        private PersonData PersonDataCRUD;
        private Patient Patient;

        public Person()
        {
            PersonDataCRUD = new PersonData();
            Patient = new Patient();
        }

        public async Task<List<Persona>> GetAll()
        {
            return await PersonDataCRUD.GetList();
        }

        public async Task<List<Persona>> GetAllMedical()
        {
            return await PersonDataCRUD.GetList(x => x.Cdtipo == Constants.MEDICAL);
        }

        public async Task InsertNewPerson(Persona entityInsert)
        {
            entityInsert.Feregistro = DateTime.Now;
            if ((entityInsert.Cdtipo != Constants.PATIENT))
                await PersonDataCRUD.Insert(entityInsert);
            else
                await Patient.InsertNewPatient(entityInsert, entityInsert.PacienteNmidMedicotraNavigations.First());
        }

        public async Task UpdatePerson(Persona entityUpdate)
        {
            var entity = await PersonDataCRUD.GetByWhere(x => x.Cddocumento.Equals(entityUpdate.Cddocumento));

            if (entity != null)
            {
                entityUpdate.Nmid = entity.Nmid;
                if (entityUpdate.PacienteNmidPersonaNavigations != null && entityUpdate.PacienteNmidPersonaNavigations.Count > 0)
                    entityUpdate.PacienteNmidPersonaNavigations.FirstOrDefault().NmidPersona = entity.Nmid;
            }
            else
                throw new Exception(Constants.NOT_FOUND);

            await PersonDataCRUD.Update(entityUpdate);
        }
    }
}
