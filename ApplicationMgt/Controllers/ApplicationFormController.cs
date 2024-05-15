using ApplicationMgt.Dtos;
using ApplicationMgt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly DemoContext _context;
        public ApplicationFormController(DemoContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProgram([FromBody] ApplicationForm request)
        {
            try
            {
                request.Id = Guid.NewGuid().ToString();

                foreach (var item in request.Fields)
                {
                    item.Id = Guid.NewGuid().ToString();
                }
                
                await _context.ApplicationForms.AddAsync(request);
                await _context.SaveChangesAsync();
                return Ok(request);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete(nameof(DeleteCustomQuestion))]
        public async Task<IActionResult> DeleteCustomQuestion(string applicationFormId, string questionId)
        {
            try
            {
                var formResponse = await _context.ApplicationForms.FirstOrDefaultAsync(c=>c.Id == applicationFormId);
                if (formResponse == null)
                {
                    return BadRequest("Application form not found");
                }

                formResponse.CustomQuestionIds.Remove(questionId);
                await _context.SaveChangesAsync();
                return Ok(formResponse);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet(nameof(GetFormFieldsByFormId))]
        public async Task<IActionResult> GetFormFieldsByFormId(string formId)
        {
            try
            {
                var form = await _context.ApplicationForms
                    .Where(form => form.Id == formId)
                    .FirstOrDefaultAsync();

                if (form == null)
                {
                    return BadRequest("Application form not found");
                }

                var customQuestions = await _context.Questions
                    .Where(question => form.CustomQuestionIds.Contains(question.Id))
                    .ToListAsync();

                var response = new ApplicationFieldsView
                {
                    Id = form.Id,
                    ProgramTitle = form.ProgramTitle,
                    ProgramDescription = form.ProgramDescription,
                    CustomQuestions = customQuestions,
                    Fields = form.Fields
                };

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
