using ApplicationMgt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly DemoContext _context;
        public CandidateController(DemoContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody] Candidate request)
        {
            try
            {
                request.Id = Guid.NewGuid().ToString();
                await _context.Candidates.AddAsync(request);
                await _context.SaveChangesAsync();

                return Ok(request);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}
