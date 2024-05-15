using Microsoft.VisualBasic.FileIO;

namespace ApplicationMgt.Models
{
    public class FormField
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public FieldType Type { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsHidden { get; set; }

    }
    public enum FieldType
    {
        Text,   
        Email,
        Phone,
        Date,
        Number,
        Dropdown
    }
}
