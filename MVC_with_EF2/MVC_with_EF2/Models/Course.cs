using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_with_EF2.Models
{
    public class Course
    {
        // the below will prevent the db from auto numbering the id
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual List<Enrollment> Enrollments { get; set; }

    }
}
