using ApplicationMgt.Dtos;
using ApplicationMgt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly DemoContext _context;
        public QuestionController(DemoContext context)
        {
            _context = context;
        }
        [HttpPost(nameof(CreateQuestion))]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDto request)
        {
            try
            {
                var question = new Question
                {
                    Id = Guid.NewGuid().ToString(),
                    Choices = request.Choices,
                    MaxChoices = request.MaxChoices,
                    QuestionText = request.Text,
                    Type = request.Type
                };

                await _context.Questions.AddAsync(question);
                await _context.SaveChangesAsync();

                return Ok(question);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet(nameof(GetQuestions))]
        public async Task<IActionResult> GetQuestions() 
        {
            try
            {
                var questions = await _context.Questions.ToListAsync();

                return Ok(questions);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto request)
        {
            try
            {
                var response = await  _context.Questions.FirstOrDefaultAsync(c=>c.Id == request.Id);
                if(response == null)
                {
                    return BadRequest("Question not found");
                }
                
                response.QuestionText = request.Text;
                response.MaxChoices = request.MaxChoices;
                response.Choices = request.Options;
                await _context.SaveChangesAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(string questionId)
        {
            try
            {
                var response = await _context.Questions.FirstOrDefaultAsync(c => c.Id == questionId);
                if (response == null)
                {
                    return BadRequest("Question not found");
                }
                var re = _context.Questions.Remove(response);
                await _context.SaveChangesAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
