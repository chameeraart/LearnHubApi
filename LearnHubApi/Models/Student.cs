using System.ComponentModel;

namespace LearnHubApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Sex { get; set; }
        public string? IdNumber { get; set; }
        public string? Password { get; set; }
        public DateTime? Birthday { get; set; }

        [DefaultValue(false)]
        public bool Status { get; set; }


    }
}
