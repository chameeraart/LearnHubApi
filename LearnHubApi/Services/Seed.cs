using LearnHubApi.Models;

namespace LearnHubApi.Services
{
    public class Seed
    {
        public LearnHubDbContext Context { get; }

        public Seed(LearnHubDbContext context)
        {

            Context = context;
        }

        public void SeedData()
        {


            var users = Context.users;

            if (users == null)
            {
                var userlist = new List<User> {
                   new User {username="admin",password="admin",UserType= LearnHubApi.Models.User.UserTypes.Admin,isactive=true},
                        new User {username=" CeylonDazzling",password="123",UserType= LearnHubApi.Models.User.UserTypes.Admin, isactive = true},
            };

                Context.AddRange(userlist);
                Context.SaveChanges();

            }

        }
    }
}
