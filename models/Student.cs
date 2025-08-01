namespace RegistrationApi.Models
{
    public class Student
    {
        public string StudentId { get; set; }  // Unique ID (you already have this)

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? PhotoUrl { get; set; }  // Photo as URL
    }
}
