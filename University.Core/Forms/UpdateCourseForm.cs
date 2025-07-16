using System.ComponentModel.DataAnnotations;

namespace University.Core.Forms
{
    public class UpdateCourseForm
    {
        [Required]
        public string CourseName { get; set; }

        [Range(typeof(DateTime), "1/1/2024", "12/31/2030")]
        public DateTime StartDate { get; set; }

        [Range(typeof(DateTime), "1/1/2024", "12/31/2030")]
        public DateTime EndDate { get; set; }
    }
}
