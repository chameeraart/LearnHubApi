using LearnHubApi.Infrastructure;
using LearnHubApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace LearnHubApi.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly LearnHubDbContext _context;

        public StudentRepository(LearnHubDbContext context)
        {
            this._context = context;
        }

        public List<Student> GetAll()
        {
          return _context.students.ToList();
        }

        public Student GetStudent(int id)
        {
            var student = _context.students.Where(x => x.Id == id).FirstOrDefault();

            if (student is null)
            {
                throw new Exception($"Student {id} is not found.");
            }
            else
            {
                return _context.students.Where(x => x.Id == id).FirstOrDefault();
            }
           
        }

        public void DeleteStudent(Student student)
        {
            var Deletestudent = _context.students.FirstOrDefault(s => s.Id == student.Id);
            if (Deletestudent != null)
            {
                _context.students.Remove(Deletestudent);
            }

        }

        public void InsertUpdateStudent(Student student) {

            _context.Update(student);
            _context.SaveChanges();

            var userlist = new List<User> {
                new User {username=student.Name,password=student.Password,UserType= LearnHubApi.Models.User.UserTypes.User,isactive=true,studentid=student.Id},
            };

            _context.AddRange(userlist);


        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
