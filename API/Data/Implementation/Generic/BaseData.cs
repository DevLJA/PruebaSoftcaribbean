using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Generic
{
    public class BaseData
    {
        public DbContext GetContext()
        {
            DesarrolloContext context = new DesarrolloContext();
            context.Database.SetCommandTimeout(new TimeSpan(0, 2, 0)); //Dos minutos            
            return context;
        }
    }
}
