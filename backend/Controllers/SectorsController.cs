using System.Collections.Generic;
using Backend.Domain.Form;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly List<Sector> _sectors;

        public SectorsController() 
        {
            _sectors = new List<Sector>();   
        }

        [HttpGet]
        public IActionResult GetSectors(){
            var sectors = _sectors!.AsQueryable();

            return Ok(sectors);
        }

        [HttpGet("{id}")]
        public IActionResult GetSector(string id){
            var sector = _sectors.FirstOrDefault(x => x.Id.ToString() == id);

            if (sector == null){
                return NotFound();
            }

            return Ok(sector);
        }
    }
}