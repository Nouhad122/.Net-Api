using System.ComponentModel.DataAnnotations;

namespace University.Core.Forms
{
    public class UpdateStudentForm
    {
        [Required]
        public string Name { get; set; }
    }
}
