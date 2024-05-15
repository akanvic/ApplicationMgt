using ApplicationMgt.Models;

namespace ApplicationMgt.Dtos
{
    public class ApplicationFieldsView
    {
        public string Id { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public List<FormField> Fields { get; set; }
        public List<Question> CustomQuestions { get; set; }
    }
}
