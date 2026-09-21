using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.AppContext
{
    public class AppDbContext : DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Teachers)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepartmentId);


            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId);


            modelBuilder.Entity<ClassRoom>()
                .HasMany(c => c.Students)
                .WithOne(s => s.ClassRoom)
                .HasForeignKey(s => s.ClassRoomId);


            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(s => s.StudentId);



            modelBuilder.Entity<Subject>()
                .HasMany(s=>s.Enrollments)
                .WithOne(e => e.Subject)
                .HasForeignKey(s=>s.SubjectId);


            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();




            modelBuilder.Entity<Enrollment>()
           .HasIndex(e => new { e.StudentId, e.SubjectId })
           .IsUnique();




            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Computer Science",
                    Description = "Software and programming department"
                },
                new Department
                {
                    Id = 2,
                    Name = "Electronics",
                    Description = "Electronics and embedded systems department"
                }
             );


            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FirstName = "Ahmed",
                    LastName = "Hassan",
                    Email = "ahmed@school.com",
                    PhoneNumber = "01012345678",
                    Salary = 15000,
                    DepartmentId = 1
                },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Mona",
                    LastName = "Ali",
                    Email = "mona@school.com",
                    PhoneNumber = "01123456789",
                    Salary = 14000,
                    DepartmentId = 1
                },
                new Teacher
                {
                    Id = 3,
                    FirstName = "Omar",
                    LastName = "Mahmoud",
                    Email = "omar@school.com",
                    PhoneNumber = "01234567890",
                    Salary = 15500,
                    DepartmentId = 2
                }
            );



            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "C++ Programming",
                    Description = "Programming fundamentals and OOP",
                    MaxGrade = 100,
                    TeacherId = 1
                },
                new Subject
                {
                    Id = 2,
                    Name = "Database Systems",
                    Description = "Database and SQL",
                    MaxGrade = 100,
                    TeacherId = 2
                },
                new Subject
                {
                    Id = 3,
                    Name = "Web Development",
                    Description = "Web development fundamentals",
                    MaxGrade = 100,
                    TeacherId = 1
                },
                new Subject
                {
                    Id = 4,
                    Name = "Embedded Systems",
                    Description = "Microcontrollers and embedded programming",
                    MaxGrade = 100,
                    TeacherId = 3
                }
            );



            modelBuilder.Entity<ClassRoom>().HasData(
                new ClassRoom
                {
                    Id = 1,
                    Name = "Software 1A",
                    GradeLevel = 10,
                    Capacity = 30
                },
                new ClassRoom
                {
                    Id = 2,
                    Name = "Electronics 1A",
                    GradeLevel = 10,
                    Capacity = 25
                }
            );


            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Mohamed",
                    Email = "ali@student.com",
                    PhoneNumber = "01011111111",
                    DateOfBirth = new DateOnly(2010, 5, 12),
                    ClassRoomId = 1
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Omar",
                    LastName = "Ahmed",
                    Email = "omar@student.com",
                    PhoneNumber = "01022222222",
                    DateOfBirth = new DateOnly(2010, 8, 20),
                    ClassRoomId = 1
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Youssef",
                    LastName = "Hany",
                    Email = "youssef@student.com",
                    PhoneNumber = "01033333333",
                    DateOfBirth = new DateOnly(2010, 3, 15),
                    ClassRoomId = 1
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Mariam",
                    LastName = "Ali",
                    Email = "mariam@student.com",
                    PhoneNumber = "01044444444",
                    DateOfBirth = new DateOnly(2010, 7, 10),
                    ClassRoomId = 2
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Salma",
                    LastName = "Mostafa",
                    Email = "salma@student.com",
                    PhoneNumber = "01055555555",
                    DateOfBirth = new DateOnly(2009, 12, 22),
                    ClassRoomId = 2
                },
                new Student
                {
                    Id = 6,
                    FirstName = "Karim",
                    LastName = "Tarek",
                    Email = "karim@student.com",
                    PhoneNumber = "01066666666",
                    DateOfBirth = new DateOnly(2010, 11, 5),
                    ClassRoomId = 2
                }
            );




            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = 1,
                    StudentId = 1,
                    SubjectId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 90
                },
                new Enrollment
                {
                    Id = 2,
                    StudentId = 1,
                    SubjectId = 2,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 85
                },
                new Enrollment
                {
                    Id = 3,
                    StudentId = 2,
                    SubjectId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 78
                },
                new Enrollment
                {
                    Id = 4,
                    StudentId = 2,
                    SubjectId = 3,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 88
                },
                new Enrollment
                {
                    Id = 5,
                    StudentId = 3,
                    SubjectId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 95
                },
                new Enrollment
                {
                    Id = 6,
                    StudentId = 4,
                    SubjectId = 4,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 82
                },
                new Enrollment
                {
                    Id = 7,
                    StudentId = 5,
                    SubjectId = 4,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 91
                },
                new Enrollment
                {
                    Id = 8,
                    StudentId = 6,
                    SubjectId = 2,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 76
                }
            );

        }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }



    }
}
