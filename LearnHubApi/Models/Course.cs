using System.ComponentModel;

namespace LearnHubApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Instructor { get; set; }
        public string Language { get; set; }
        public DateTime? Created_datetime { get; set;}
        public decimal Fee { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
