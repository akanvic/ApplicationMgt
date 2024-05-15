using ApplicationMgt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMgt.Controllers
{
    [ApiController]
    [Route("cosmos")]
    public class CosmosController : ControllerBase
    {
        private readonly DemoContext _dbContext;
        private static bool _ensureCreated { get; set; } = false;

        public CosmosController(DemoContext dbContext)
        {
            _dbContext = dbContext;

            if (!_ensureCreated)
            {
                _dbContext.Database.EnsureCreated();
                _ensureCreated = true;
            }
        }
        //[HttpPost(Name = "Create")]
        //public async Task<IActionResult> Create()
        //{
        //    var obj = new Question()
        //    {
        //        Choice = "Choice",
        //        QuestionDesc = "QuestionDesc",
        //        QuestionType = 1
        //    };
        //    await _dbContext.AddAsync(obj);
        //    await _dbContext.SaveChangesAsync();

        //    return Ok(obj);
        //}
        [HttpGet(Name = "GetQuestion")]
        public async Task<IActionResult> GetQuestion()
        {
            var obj = await _dbContext.Questions.ToListAsync();

            return Ok(obj);
        }
    }
}
