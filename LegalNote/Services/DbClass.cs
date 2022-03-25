using LegalNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalNote.Services
{
    public static class DbClass
    {
        private static legalnoteEntities _legEnt = new legalnoteEntities(Singleton.Instance.DbConnectionString);

        public static legalnoteEntities LegEnt { get => _legEnt; set => _legEnt = value; }
    }
}
