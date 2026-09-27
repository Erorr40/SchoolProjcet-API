using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassRooms",
                columns: new[] { "Id", "Capacity", "GradeLevel", "Name" },
                values: new object[,]
                {
                    { 1, 30, 10, "Software 1A" },
                    { 2, 25, 10, "Electronics 1A" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Software and programming department", "Computer Science" },
                    { 2, "Electronics and embedded systems department", "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassRoomId", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2010, 5, 12), "ali@student.com", "Ali", "Mohamed", "01011111111" },
                    { 2, 1, new DateOnly(2010, 8, 20), "omar@student.com", "Omar", "Ahmed", "01022222222" },
                    { 3, 1, new DateOnly(2010, 3, 15), "youssef@student.com", "Youssef", "Hany", "01033333333" },
                    { 4, 2, new DateOnly(2010, 7, 10), "mariam@student.com", "Mariam", "Ali", "01044444444" },
                    { 5, 2, new DateOnly(2009, 12, 22), "salma@student.com", "Salma", "Mostafa", "01055555555" },
                    { 6, 2, new DateOnly(2010, 11, 5), "karim@student.com", "Karim", "Tarek", "01066666666" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "ahmed@school.com", "Ahmed", "Hassan", "01012345678", 15000m },
                    { 2, 1, "mona@school.com", "Mona", "Ali", "01123456789", 14000m },
                    { 3, 2, "omar@school.com", "Omar", "Mahmoud", "01234567890", 15500m }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "MaxGrade", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Programming fundamentals and OOP", 100, "C++ Programming", 1 },
                    { 2, "Database and SQL", 100, "Database Systems", 2 },
                    { 3, "Web development fundamentals", 100, "Web Development", 1 },
                    { 4, "Microcontrollers and embedded programming", 100, "Embedded Systems", 3 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "EnrollmentDate", "Grade", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, 1, 1 },
                    { 2, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85m, 1, 2 },
                    { 3, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78m, 2, 1 },
                    { 4, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88m, 2, 3 },
                    { 5, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95m, 3, 1 },
                    { 6, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82m, 4, 4 },
                    { 7, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91m, 5, 4 },
                    { 8, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76m, 6, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
