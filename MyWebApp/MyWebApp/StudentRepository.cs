using MyWebApp.Models;

namespace MyWebApp
{
    public class StudentRepository
    {
        private List<StudentViewModel> _mockStudents;

        public StudentRepository()
        {
            CreateMockStudentList();
        }
        private void CreateMockStudentList()
        {
            _mockStudents = new List<StudentViewModel>();
            _mockStudents.Add(new StudentViewModel { Id = 1, Name = "Steve", Course = "AHBC C#" });
            _mockStudents.Add(new StudentViewModel { Id = 2, Name = "Mary", Course = "AHBC C#" });
            _mockStudents.Add(new StudentViewModel { Id = 3, Name = "David", Course = "AHBC C#" });
            _mockStudents.Add(new StudentViewModel { Id = 4, Name = "Kate", Course = "AHBC C#" });
        }
        public IEnumerable<StudentViewModel> GetMockStudents()
        {
            return _mockStudents;
        }

    }

}
