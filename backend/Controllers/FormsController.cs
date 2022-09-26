using Microsoft.AspNetCore.Mvc;
using Backend.Data.Form;
using Backend.Data.Common;
using Backend.ViewModels;
using Backend.Controllers.Aids;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormsController : ControllerBase
    {
        private readonly DataContext _context;
        public FormsController(DataContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] FormViewModel form)
        {
            if (string.IsNullOrWhiteSpace(form.SubmitterName.Trim()))
            {
                return BadRequest();
            }

            if (form.SectorNames.Length == 0 || SectorHandler.ContainsSectors(form.SectorNames, _context!.Sectors.ToList()) == false){
                return BadRequest();
            }

            FormData formData = new() {
                Id = Guid.NewGuid(),
                SubmitterName = form.SubmitterName,
                CreatedAt = form.CreatedAt
            };

            var sectorForms = SectorHandler.Map(_context!.Sectors, formData, form.SectorNames);

            _context.Forms?.Add(formData);
            _context.FormSectors.AddRange(sectorForms);
            
            _context.SaveChanges();

            return CreatedAtAction(nameof(Create), new {Form = formData});
        }
    }
}