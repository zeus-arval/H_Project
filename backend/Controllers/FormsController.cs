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

            // if (sectorNames.Length == 0 || SectorHandler.ContainsSectors(sectorNames, _context!.Sectors.ToList()) == false){
            //     return BadRequest();
            // }

            FormData formData = new() {
                Id = Guid.NewGuid(),
                SubmitterName = form.SubmitterName,
                CreatedAt = form.CreatedAt
            };

            _context.Forms?.Add(formData);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Create), new {Form = formData});
        }
    }
}