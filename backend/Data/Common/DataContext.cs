using System;
using System.Linq;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Backend.Data.Form;
using Npgsql;

namespace Backend.Data.Common
{
    public class DataContext : DbContext
    {
        private readonly List<(int Level, string Name)> levelsNamesArray = new()
        {
            (0, "Construction materials"),
            (1, "Manufacturing"),
            (1, "Electronics and Optics"),
            (1, "Food and Beverage"),
            (2, "Bakery & confectionery products"),
            (2, "Beverages"),
            (2, "Fish & fish products"),
            (2, "Meat & meat products"),
            (2, "Milk & dairy products"),
            (2, "Other"),
            (2, "Sweets & snack food"),
            (1, "Furniture"),
            (2, "Bathroom/sauna"),
            (2, "Bedroom"),
            (2, "Children's room"),
            (2, "Kitchen"),
            (2, "Living room"),
            (2, "Office"),
            (2, "Other (Furniture)"),
            (2, "Outdoor"),
            (2, "Project furniture"),
            (1, "Machinery"),
            (2, "Machinery components"),
            (2, "Machinery equipment/tools"),
            (2, "Manufacture of machinery"),
            (2, "Maritime"),
            (3, "Aluminium and steel workboats"),
            (3, "Boat/Yacht building"),
            (3, "Ship repair and conversion"),
            (2, "Metal structures"),
            (2, "Other"),
            (2, "Repair and maintenance service"),
            (1, "Metalworking"),
            (2, "Construction of metal structures"),
            (2, "Houses and buildings"),
            (2, "Metal products"),
            (2, "Metal works"),
            (3, "CNC-machining"),
            (3, "Forgings, Fasteners"),
            (3, "Gas, Plasma, Laser cutting"),
            (3, "MIG, TIG, Aluminum welding"),
            (1, "Plastic and Rubber"),
            (2, "Packaging"),
            (2, "Plastic goods"),
            (2, "Plastic processing technology"),
            (3, "Blowing"),
            (3, "Moulding"),
            (3, "Plastics welding and processing"),
            (2, "Plastic profiles"),
            (1, "Printing"),
            (2, "Advertising"),
            (2, "Book/Periodicals printing"),
            (2, "Labelling and packaging printing"),
            (1, "Textile and Clothing"),
            (2, "Clothing"),
            (2, "Textile"),
            (1, "Wood"),
            (2, "Other (Wood)"),
            (2, "Wooden building materials"),
            (2, "Wooden houses"),
            (0, "Other"),
            (1, "Creative industries"),
            (1, "Energy technology"),
            (1, "Environment"),
            (0, "Service"),
            (1, "Business services"),
            (1, "Engineering"),
            (1, "Information Technology and Telecommunications"),
            (2, "Data processing, Web portals, E-marketing"),
            (2, "Programming, Consultancy"),
            (2, "Software, Hardware"),
            (2, "Telecommunications"),
            (1, "Tourism"),
            (1, "Translation services"),
            (1, "Transport and Logistics"),
            (2, "Air"),
            (2, "Rail"),
            (2, "Road"),
            (2, "Water"),
        };
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SectorData> Sectors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SectorData>().Property(p => p.Id);

            builder.Entity<SectorData>().HasData(
                GenerateSectors()
            );
        }


        private IEnumerable<SectorData> GenerateSectors()
        {
            Guid[] Parents = new Guid[3];
            int length = levelsNamesArray.Count;
            List<SectorData> sectors = new List<SectorData>();

            for(int i = 0; i < length; i++)
            {
                var sectorLevelName = levelsNamesArray[i];

                SectorData sector = new() {
                    Id = Guid.NewGuid(),
                    Name = sectorLevelName.Name
                };

                if (i != length - 1 && levelsNamesArray[i + 1].Level > sectorLevelName.Level)
                {
                    Parents[sectorLevelName.Level] = sector.Id;
                }

                if (sectorLevelName.Level > 0) sector.ParentId = Parents?[sectorLevelName.Level - 1] ?? Guid.Empty;

                sectors.Add(sector);
            }

            return sectors;
        }
    }
}