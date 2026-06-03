using EducationPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.DTOs
{
    public class StudentResultDto
    {
     public bool IsFound { get; set; }
     public bool IsForbidden { get; set; }
     public Student Student { get; set; }

    }
}
