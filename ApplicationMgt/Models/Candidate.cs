using System.ComponentModel.DataAnnotations;

namespace ApplicationMgt.Models
{
    public class Candidate
    {
        public string Id { get; set; }
        public string ApplicationFormId { get; set; }
        public Dictionary<string, string> FieldResponses { get; set; } //FormFieldId, FieldResponse
        public Dictionary<string, List<string>> QuestionResponses { get; set; } //QuestionId, QuestionResponse
    }
}
