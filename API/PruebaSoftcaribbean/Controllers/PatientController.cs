using Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using PruebaSoftcaribbean.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSoftcaribbean.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {

        private readonly IPatient PatientService;
        public PatientController(IPatient patientService)
        {
            PatientService = patientService;
        }

        [HttpPost]
        [Route("CreateNewPatient")]
        public async Task<GenericResponse<Task>> CreateNewPatient(Paciente newPerson)
        {
            return await GenericExecution.RunAsync(PatientService.InsertNewPatient(newPerson));
        }

        [HttpGet]
        [Route("GetAllPatients")]
        public async Task<GenericResponse<List<Persona>>> GetAllPatients()
        {
            return await GenericExecution.RunAsync(PatientService.GetAllPatients());
        }

    }
}
