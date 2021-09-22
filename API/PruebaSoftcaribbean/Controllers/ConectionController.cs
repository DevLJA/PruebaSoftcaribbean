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
    public class ConectionController : ControllerBase
    {
        public string Get()
        {
            return "Conexión exitosa";
        }
    }
}
