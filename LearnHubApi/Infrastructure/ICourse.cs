using LearnHubApi.Models;

namespace LearnHubApi.Infrastructure
{
    public interface ICourse
    {
        List<Course> GetAllCourse();
        Course GetCourse(int id);
        void DeleteCourse(Course course);
        void InsertUpdateCourse(Course course);
        void SaveCourse();
    }
}
