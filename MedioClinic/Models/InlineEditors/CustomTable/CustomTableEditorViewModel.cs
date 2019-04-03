namespace MedioClinic.Models.InlineEditors
{
    public class CustomTableEditorViewModel : InlineEditorViewModel
    {
        public string CustomTableCodeName { get; set; }
        public int MaxRows { get; set; }
        public string OrderBy { get; set; }
    }
}