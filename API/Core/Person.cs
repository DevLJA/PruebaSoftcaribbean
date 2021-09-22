using Core.Utils;
using Data.Implementation;
using Interfaces.Core;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public class Person : IPerson
    {
        private PersonData PersonDataCRUD;
        public Person()
        {
            PersonDataCRUD = new PersonData();
        }
        public async Task InsertNewPerson(Persona entityInsert)
        {
            await PersonDataCRUD.Insert(entityInsert);

        }

        public async Task UpdatePerson(Persona entityUpdate)
        {
            var entity = await PersonDataCRUD.GetByWhere(x => x.Cddocumento.Equals(entityUpdate.Cddocumento));

            if (entity != null)
                entityUpdate.Nmid = entity.Nmid;
            else
                throw new Exception(Constants.NOT_FOUND);

            await PersonDataCRUD.Update(entityUpdate);
        }
    }
}
