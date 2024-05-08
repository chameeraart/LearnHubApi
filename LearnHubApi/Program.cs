using LearnHubApi.Infrastructure;
using LearnHubApi.Models;
using LearnHubApi.Repository;
using LearnHubApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<LearnHubDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<InitMigrations>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<SessionManager>();
builder.Services.AddScoped<Seed>();
builder.Services.AddScoped<IStudent, StudentRepository>(); // Assuming StudentRepository is the implementation
builder.Services.AddScoped<IAuth, AuthRepository>(); // Assuming AuthRepository is the implementation
builder.Services.AddScoped<ICourse, CourseRepository>(); // Assuming CourseRepository is the implementation
builder.Services.AddScoped<IEnroll, EnrollRepository>(); // Assuming EnrollRepository is the implementation

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});


// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(options =>
 {
     options.SaveToken = true;
     options.RequireHttpsMetadata = false;
     options.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidAudience = LearnHubApi.Services.SessionManager.Audiance,
         ValidIssuer = LearnHubApi.Services.SessionManager.Issuer,
         IssuerSigningKey = new SymmetricSecurityKey(LearnHubApi.Services.SessionManager.salt)
     };
 });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var initMigrations = services.GetRequiredService<InitMigrations>();
    var context = services.GetRequiredService<LearnHubDbContext>();
    var session = services.GetRequiredService<SessionManager>();
    initMigrations.MigrateDatabase();

    var seed = services.GetRequiredService<Seed>();
    seed.SeedData();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseCors("AllowAnyOrigin");
    // Authentication & Authorization
    app.UseAuthentication();

    app.UseAuthorization();
}
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
