using AutoMapper;
using EducationPlatform.Application.DTOs;
using EducationPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //student
            CreateMap<Student, StudentDTO>();


            CreateMap<AddStudentDTO, Student>()
            .ForMember(dest => dest.ImgPath, opt => opt.Ignore());


            CreateMap<UpdateStudentDTO, Student>()
            .ForMember(dest => dest.ImgPath, opt => opt.Ignore());
            //Role
           


        }
    }

}
