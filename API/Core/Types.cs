using Core.Utils;
using Data.Implementation;
using Interfaces.Core;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public class Types : ITypes
    {
        private PersonTypeData PersonTypeDataCRUD;
        private GendersData GendersDataCRUD;
        public Types()
        {
            PersonTypeDataCRUD = new PersonTypeData();
            GendersDataCRUD = new GendersData();
        }

        public async Task<List<Genero>> GetGenders()
        {
            return await GendersDataCRUD.GetList();
        }

        public async Task<List<TiposPersona>> GetPersonType()
        {
            return await PersonTypeDataCRUD.GetList();
        }
    }
}
