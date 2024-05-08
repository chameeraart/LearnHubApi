using LearnHubApi.Infrastructure;
using LearnHubApi.Models;

namespace LearnHubApi.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly LearnHubDbContext _context;

        public CourseRepository(LearnHubDbContext context)
        {
            this._context = context;
        }

        public List<Course> GetAllCourse()
        {
            return _context.courses.ToList();
        }

        public Course GetCourse(int id)
        {
            var student = _context.courses.Where(x => x.Id == id).FirstOrDefault();

            if (student is null)
            {
                throw new Exception($"Course {id} is not found.");
            }
            else
            {
                return _context.courses.Where(x => x.Id == id).FirstOrDefault();
            }

        }

        public void DeleteCourse(Course course)
        {
            var deleteCourese = _context.courses.FirstOrDefault(s => s.Id == course.Id);
            if (deleteCourese != null)
            {
                _context.courses.Remove(deleteCourese);
            }

        }

        public void InsertUpdateCourse(Course course)
        {
            _context.Update(course);
        }

        public void SaveCourse()
        {
            _context.SaveChanges();
        }
    }
}
