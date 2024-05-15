using ApplicationMgt.Models;
using System.ComponentModel.DataAnnotations;

namespace ApplicationMgt.Dtos
{
    public class UpdateQuestionDto
    {
        public string? Id { get; set; }
        public int Type { get; set; }
        public string Text { get; set; }
        public int? MaxChoices { get; set; }
        public List<string>? Options { get; set; }
    }
}
