using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSoftcaribbean.Utils
{
    public class GenericResponse<T>
    {
        public bool Successful { get; set; }
        public T Response { get; set; }
        public string MessageError { get; set; }

        public GenericResponse()
        {
            Successful = false;
        }
        public void LogError(Exception error)
        {
            Successful = false;
            MessageError = $"{error?.Message} {error?.StackTrace}";
        }
        public void LogError(string error)
        {
            Successful = false;
            if (string.IsNullOrEmpty(error))
                error = "Error without description";
            MessageError = error;
        }

    }
}
