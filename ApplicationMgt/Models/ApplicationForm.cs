using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ApplicationMgt.Models
{
    public class ApplicationForm
    {
        [Key]
        public string Id { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public List<FormField> Fields { get; set; }
        public List<string> CustomQuestionIds { get; set; }
    }
}
