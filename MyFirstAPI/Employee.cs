namespace MyFirstAPI
{
    public class Employee
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Title { get; set; }

    }

    public class EmployeeEducation
    {
        public int ID { get; set; }

        public string? CourseName { get; set; }

        public int Marks { get; set; }

    }

    public class EmployeeRequest
    {
        public Employee EmployeePersonalInfo { get; set; }

        public EmployeeEducation EducationalDetails { get; set; }
    }
}
