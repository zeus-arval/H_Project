using System.Collections.Generic;
using Backend.Data.Form;
using Backend.ViewModels;
using Backend.Data.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly DataContext _context;
        public SectorsController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSectors(){
            var sectors = _context.Sectors?.Select(x => new SectorViewModel(x.Name, FindParentName(x.ParentId)));

            return Ok(sectors);
        }

        private string FindParentName(Guid id) => _context?.Sectors.FirstOrDefault(x => x.Id == id)?.Name ?? SectorData.Unspecified;
    }
}