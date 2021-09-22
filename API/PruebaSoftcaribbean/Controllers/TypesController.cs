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
    public class TypesController : ControllerBase
    {

        private readonly ITypes TypesService;
        public TypesController(ITypes typesService)
        {
            TypesService = typesService;
        }

        [HttpGet]
        [Route("GetGenders")]
        public async Task<GenericResponse<List<Genero>>> GetGenders()
        {
            return await GenericExecution.RunAsync(TypesService.GetGenders());
        }

        [HttpGet]
        [Route("GetPersonType")]
        public async Task<GenericResponse<List<TiposPersona>>> GetPersonType()
        {
            return await GenericExecution.RunAsync(TypesService.GetPersonType());
        }
    }
}
