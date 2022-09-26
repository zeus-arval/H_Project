using Microsoft.AspNetCore.Mvc;
using Backend.Data.Form;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Controllers.Aids
{
    public static class SectorHandler
    {
        public static bool ContainsSectors(string[] sectorNames, List<SectorData> sectors)
        {
            foreach(string name in sectorNames)
            {
                if (sectors.Any(x => x.Name == name) == false){
                    return false;
                }
            }

            return true;
        }
    }
}