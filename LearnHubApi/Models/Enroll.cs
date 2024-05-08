using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearnHubApi.Models
{
    public class Enroll
    {
        public int Id { get; set; }

        // Foreign key for Student
        public int? StudentId { get; set; }

        // Navigation property for Student
        [ForeignKey("StudentId")]
        [JsonIgnore]
        public virtual Student? Student { get; set; }

        // Foreign key for Course
        public int? CourseId { get; set; }

        // Navigation property for Course
        [ForeignKey("CourseId")]
        [JsonIgnore]
        public virtual Course? Course { get; set; }

        public DateTime Created_datetime { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
