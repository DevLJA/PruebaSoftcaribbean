using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSoftcaribbean.Utils
{
    public class GenericExecution
    {
        public static async Task<GenericResponse<T>> RunAsync<T>(Task<T> method)
        {
            var result = new GenericResponse<T>() { Successful = true };
            try
            {
                result.Response = await method;
                result.Successful = result.Response != null;
            }
            catch (Exception error)
            {
                result.LogError(error);
            }
            return result;
        }

        public async static Task<GenericResponse<Task>> RunAsync(Task method)
        {
            var result = new GenericResponse<Task>() { Successful = true };
            try
            {
                await method;
            }
            catch (ArithmeticException error)
            {
                result.LogError(error);
            }
            catch (ArgumentNullException error)
            {
                result.LogError(error);
            }
            catch (Exception error)
            {
                result.LogError(error);
            }
            return result;
        }

    }
}
