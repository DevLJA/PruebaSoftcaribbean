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
            var result = await PersonDataCRUD.GetListIncludeProperties(x => true, x => x.PacienteNmidPersonaNavigations);
            result.ForEach(x =>
            {
                if (x.PacienteNmidPersonaNavigations != null && x.PacienteNmidPersonaNavigations.Count > 0)
                {
                    x.PacienteNmidPersonaNavigations.First().NmidMedicotraNavigation = null;
                    x.PacienteNmidPersonaNavigations.First().NmidPersonaNavigation = null;
                }
            });
            return result;
        }

        public async Task<List<Persona>> GetAllMedical()
        {
            return await PersonDataCRUD.GetList(x => x.Cdtipo == Constants.MEDICAL);
        }

        public async Task InsertNewPerson(Persona entityInsert)
        {
            var entity = await PersonDataCRUD.GetByWhere(x => x.Cddocumento.Equals(entityInsert.Cddocumento));
            if (entity == null)
            {
                entityInsert.Feregistro = DateTime.Now;
                if ((entityInsert.Cdtipo != Constants.PATIENT))
                {
                    entityInsert.PacienteNmidMedicotraNavigations = null;
                    entityInsert.PacienteNmidPersonaNavigations = null;
                    await PersonDataCRUD.Insert(entityInsert);
                }
                else
                    await Patient.InsertNewPatient(entityInsert, entityInsert.PacienteNmidPersonaNavigations.First());
            }
            else
                await UpdatePerson(entityInsert);
        }

        public async Task UpdatePerson(Persona entityUpdate)
        {
            var entity = await PersonDataCRUD.GetListIncludeProperties(x => x.Cddocumento.Equals(entityUpdate.Cddocumento), x => x.PacienteNmidPersonaNavigations);
            var firstElement = entity.FirstOrDefault();
            if (firstElement != null)
            {
                entityUpdate.Nmid = firstElement.Nmid;
                if (entityUpdate.PacienteNmidPersonaNavigations != null && entityUpdate.PacienteNmidPersonaNavigations.Count > 0 && entityUpdate.Cdtipo == Constants.PATIENT)
                {
                    entityUpdate.PacienteNmidPersonaNavigations.FirstOrDefault().NmidPersona = firstElement.Nmid;
                    int? infoPatient = firstElement?.PacienteNmidPersonaNavigations?.FirstOrDefault()?.Nmid;
                    if (infoPatient != null)
                        entityUpdate.PacienteNmidPersonaNavigations.FirstOrDefault().Nmid = infoPatient.Value;
                }
                else
                    entityUpdate.PacienteNmidMedicotraNavigations = null;
            }
            else
                throw new Exception(Constants.NOT_FOUND);

            await PersonDataCRUD.Update(entityUpdate);
        }
    }
}
