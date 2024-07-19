using System.ComponentModel.DataAnnotations;

namespace crud_assignment.model
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Department { get; set; }
    }
}
