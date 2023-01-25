using System.ComponentModel;

namespace MyWebApp.Models
{
    public class StudentViewModel
    {
        [DisplayName("Student ID")]
        public int Id { get; set; }

        [DisplayName("Student Name")]
        public string Name { get; set; }

        [DisplayName("Current Course")]
        public string Course { get; set; }

        [DisplayName("Technical Experience")]
        public string? TechnicalExperience { get; set; }

        [DisplayName("Previous Course Count")]
        public int? PreviousCourseCount { get; set; }

    }

}
