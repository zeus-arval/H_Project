using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormsController : ControllerBase
    {
        public FormsController() { }

        [HttpPost]
        public IActionResult Create([FromBody] string form)
        {
            return CreatedAtAction(nameof(Create), new {Form = form});
        }
    }
}