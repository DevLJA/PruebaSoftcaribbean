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

        public async Task InsertNewPatient(Persona personInsert, Paciente entityInsert)
        {
            personInsert.PacienteNmidMedicotraNavigations = null;
            var newPerson = await PersonDataCRUD.Insert(personInsert);
            entityInsert.NmidPersona = newPerson.Nmid;
            await PatientDataCRUD.Insert(entityInsert);
        }

        public async Task<List<Persona>> GetAllPatients()
        {
            return await PersonDataCRUD.GetListIncludeProperties(x => x.Cdtipo == Constants.PATIENT, x => x.CdtipoNavigation, x => x.CdgeneroNavigation, x => x.PacienteNmidPersonaNavigations, x => x.PacienteNmidMedicotraNavigations);
        }

        public async Task<List<Paciente>> GetAll()
        {
            return await PatientDataCRUD.GetListIncludeProperties(x => true, x => x.NmidPersonaNavigation, x => x.NmidPersonaNavigation.CdgeneroNavigation, x => x.NmidPersonaNavigation.CdtipoNavigation);
        }
    }
}
