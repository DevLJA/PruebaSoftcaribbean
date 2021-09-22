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
    public class PersonController : ControllerBase
    {

        private readonly IPerson PersonService;
        public PersonController(IPerson personService)
        {
            PersonService = personService;
        }

        [HttpPost]
        [Route("CreateNewPerson")]
        public async Task<GenericResponse<Task>> CreateNewPerson(Persona newPerson)
        {
            return await GenericExecution.RunAsync(PersonService.InsertNewPerson(newPerson));
        }

        [HttpPost]
        [Route("UpdatePerson")]
        public async Task<GenericResponse<Task>> UpdatePerson(Persona newPerson)
        {
            return await GenericExecution.RunAsync(PersonService.UpdatePerson(newPerson));
        }
    }
}
