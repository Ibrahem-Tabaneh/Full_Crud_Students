using EducationPlatform.Application.DTOs;
using EducationPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
        Task<float>GetAvgStudentsAsync();
        Task<IEnumerable<Student>> GetStudentsPassed();
        Task<IEnumerable<Student>> GetStudentsFailed();

    }
}
