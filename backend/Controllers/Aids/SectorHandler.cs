using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Backend.Data.Form;
using Backend.ViewModels;
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
                if (sectors.Any(x => x.Name == name.Trim()) == false){
                    return false;
                }
            }

            return true;
        }

        public static bool CheckName(string fullName)
        {
            string pattern = @"^[a-z ,.'-]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(fullName);
        }

        public static IEnumerable<FormSectorData> Map(IEnumerable<SectorData> sectors, FormData form, string[] formSectorNames)
        {
            FormSectorData[] formSectors = new FormSectorData[formSectorNames.Count()];

            for(int i = 0; i < formSectorNames.Count(); i++)
            {
                var sector = sectors.FirstOrDefault(x => x.Name == formSectorNames[i]);
                formSectors[i] = Map(sector!, form);
            }

            return formSectors;
        }

        private static FormSectorData Map(SectorData sector, FormData form)
        {
            return new() {
                Id = Guid.NewGuid(),
                SectorId = sector.Id,
                FormId = form.Id
            };
        }
    }
}