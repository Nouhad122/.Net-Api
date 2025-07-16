using System.ComponentModel.DataAnnotations;

namespace University.Core.Forms
{
    public class CreateStudentForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
    