namespace PISA_APP.Models
{
    public enum UserRole
    {
        Admin,
        Teacher,
        Student
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }

    public class Admin : User
    {
        public Admin()
        {
            Role = UserRole.Admin;
        }
    }

    public class Teacher : User
    {
        public Teacher()
        {
            Role = UserRole.Teacher;
        }
        public List<int> AssignedSubjectIds { get; set; } = new();
    }

    public class Student : User
    {
        public Student()
        {
            Role = UserRole.Student;
        }
        public string StudentId { get; set; } = string.Empty;
        public List<int> EnrolledSubjectIds { get; set; } = new();
    }
}