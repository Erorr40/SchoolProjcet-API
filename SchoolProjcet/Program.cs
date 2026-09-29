
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.Repo;

namespace SchoolProjcet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefCon")));
            builder.Services.AddScoped<IGenaricRepo<Department>, GenericRepo<Department>>();
            builder.Services.AddScoped<IGenaricRepo<Teacher>, GenericRepo<Teacher>>();
            builder.Services.AddScoped<IGenaricRepo<Student>, GenericRepo<Student>>();
            builder.Services.AddScoped<IGenaricRepo<Subject>, GenericRepo<Subject>>();
            builder.Services.AddScoped<ISubject, SubjectRepo>();
            builder.Services.AddScoped<IGenaricRepo<Enrollment>, GenericRepo<Enrollment>>();
            builder.Services.AddScoped<ITeacherRepo, TeacherRepo>();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
