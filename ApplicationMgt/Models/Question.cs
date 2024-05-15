using System.ComponentModel.DataAnnotations;

namespace ApplicationMgt.Models
{
    public class Question
    {
        [Key]
        public string Id { get; set; }
        public QuestionTypeEnum Type { get; set; }
        public string QuestionText { get; set; }
        public int? MaxChoices { get; set; }
        public List<string>? Choices { get; set; }
    }
}
