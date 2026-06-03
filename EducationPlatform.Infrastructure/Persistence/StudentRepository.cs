using EducationPlatform.Application.DTOs;
using EducationPlatform.Application.Interfaces;
using EducationPlatform.Domain.Entities;
using EducationPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.Persistence
{
  
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddStudentAsync(Student student)
        {
            student.Password = BCrypt.Net.BCrypt.HashPassword(student.Password);
            context.Students.Add(student);
            await context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Student student)
        {
            context.Students.Remove(student);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await context.Students.ToListAsync();
        }

       public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = context.Students.FirstOrDefault(x => x.Id == id);

            return student;
        }


        public async Task UpdateStudentAsync(Student student)
        {
            student.Password = BCrypt.Net.BCrypt.HashPassword(student.Password);
            await context.SaveChangesAsync();
        }

        public async Task<float> GetAvgStudentsAsync()
        {
            var result = await context.Students.AverageAsync(x => (float?)x.Grade);
            return result != null ? (float) result : 0;
        }

        public async Task<IEnumerable<Student>> GetStudentsPassed()
        {
            var passedStudent = await context.Students.Where(x => x.Grade >= 50).ToListAsync();
            return passedStudent;
        }

        public async Task<IEnumerable<Student>> GetStudentsFailed()
        {
            var failedStudent = await context.Students.Where(x => x.Grade < 50).ToListAsync();
            return failedStudent;
        }

       
    }

}
