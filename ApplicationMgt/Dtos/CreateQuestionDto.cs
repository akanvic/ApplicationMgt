using ApplicationMgt.Models;

namespace ApplicationMgt.Dtos
{
    public class CreateQuestionDto
    {
        public QuestionTypeEnum Type { get; set; }
        public string Text { get; set; }
        public int? MaxChoices { get; set; }
        public List<string>? Choices { get; set; }
    }
}
