using LearnHubApi.Models;

namespace LearnHubApi.Infrastructure
{
    public interface IEnroll
    {
        List<Enroll> GetAllEnroll();
        Enroll GetEnroll(int id);
        void DeleteEnroll(Enroll enroll);
        void InsertUpdateEnroll(Enroll enroll);
        void SaveEnroll();

        List<Enroll> GetAllEnrollUser(int id);
    }
}
