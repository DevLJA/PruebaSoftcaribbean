using Core.Utils;
using Data.Implementation;
using Interfaces.Core;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public class Patient : IPatient
    {
        private PersonData PersonDataCRUD;
        private PatientData PatientDataCRUD;
        public Patient()
        {
            PersonDataCRUD = new PersonData();
            PatientDataCRUD = new PatientData();
        }

        public async Task InsertNewPatient(Paciente entityInsert)
        {
            var person = await PersonDataCRUD.GetByWhere(x => x.Nmid == entityInsert.NmidPersona && x.Cdtipo != Constants.PATIENT);
            if (person != null)
            {
                person.Cdtipo = Constants.PATIENT;
                await PersonDataCRUD.Update(person);
                await PatientDataCRUD.Insert(entityInsert);
            }
            else
                throw new Exception(Constants.NOT_ALLOWED);
        }

        public async Task<List<Persona>> GetAllPatients()
        {
            return await PersonDataCRUD.GetListIncludeProperties(x => x.Cdtipo == Constants.PATIENT, x => x.CdtipoNavigation, x => x.CdgeneroNavigation, x => x.PacienteNmidPersonaNavigations, x => x.PacienteNmidMedicotraNavigations);
        }
    }
}
