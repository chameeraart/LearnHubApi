using LearnHubApi.Infrastructure;
using LearnHubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnHubApi.Repository
{
    public class EnrollRepository : IEnroll
    {
        private readonly LearnHubDbContext _context;

        public EnrollRepository(LearnHubDbContext context)
        {
            this._context = context;
        }

        public List<Enroll> GetAllEnroll()
        {
            return _context.enrolls
           .Include(e => e.Student) // Include the Student navigation property
           .Include(e => e.Course)  // Include the Course navigation property
           .ToList();


        }

        public Enroll GetEnroll(int id)
        {
            var enroll = _context.enrolls.Where(x => x.Id == id).FirstOrDefault();

            if (enroll is null)
            {
                throw new Exception($"Enroll {id} is not found.");
            }
            else
            {
                return _context.enrolls.Where(x => x.Id == id).FirstOrDefault();
            }

        }

        public List<Enroll> GetAllEnrollUser(int id)
        {
            var enroll = _context.enrolls.Where(x => x.StudentId == id).FirstOrDefault();

            if (enroll is null)
            {
                return new List<Enroll>(); // Return an empty list
            }
            else
            {
                return _context.enrolls.Where(x => x.StudentId == id).ToList();
            }

        }

        public void DeleteEnroll(Enroll enroll)
        {
            var deleenroll = _context.enrolls.FirstOrDefault(s => s.Id == enroll.Id);
            if (deleenroll != null)
            {
                _context.enrolls.Remove(deleenroll);
            }

        }

        public void InsertUpdateEnroll(Enroll enroll)
        {
            _context.Update(enroll);
        }

        public void SaveEnroll()
        {
            _context.SaveChanges();
        }
    }
}
