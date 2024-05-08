using LearnHubApi.Models;
using Microsoft.EntityFrameworkCore;


namespace LearnHubApi.Services
{
    public class InitMigrations
    {
        private readonly LearnHubDbContext context;
        public InitMigrations(LearnHubDbContext context)
        {
            this.context = context;
        }
        public void MigrateDatabase()
        {
            context.Database.Migrate();
        }
    }
}
