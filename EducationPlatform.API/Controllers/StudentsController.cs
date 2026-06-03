using AutoMapper;
using EducationPlatform.API.Helpers;
using EducationPlatform.Application.DTOs;
using EducationPlatform.Application.Interfaces;
using EducationPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EducationPlatform.API.Controllers
{
    [Authorize]
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IFileService fileService;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IFileService fileService, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }

        [Authorize(Roles = "admin")]
        [HttpGet(Name = "getAllStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]


        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudentsAsync()
        {
            var listStudent = await studentRepository.GetAllStudentsAsync();
            var listStudentDTO = mapper.Map<List<StudentDTO>>(listStudent);
            return Ok(listStudentDTO);
        }

        [AllowAnonymous]
        [HttpGet("getStudentsAvg")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> getStudentsAvg()
        {
            var avg = await studentRepository.GetAvgStudentsAsync();
            return Ok(avg);
        }


        [AllowAnonymous]
        [HttpGet("getPassedStudent", Name = "getPassedStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetPassedStudent()
        {
            var studentsPassed = await studentRepository.GetStudentsPassed();
            var studentsPassedDTO = mapper.Map<List<StudentDTO>>(studentsPassed);
            return Ok(studentsPassedDTO);
        }
        
        [AllowAnonymous]
        [HttpGet("getFailedStudent", Name = "getFailedStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetFailedStudent()
        {
            var studentsFailed = await studentRepository.GetStudentsFailed();
            var studentsFailedDTO = mapper.Map<List<StudentDTO>>(studentsFailed);
            return Ok(studentsFailedDTO);
        }

        [HttpGet("getStudentById/{id}", Name = "getStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public async Task<ActionResult<StudentDTO>> GetStudentByIdAsync(int id)
        {
            if (id <= 0) return BadRequest("invalid id.");

            var student = await studentRepository.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            if(!User.IsOwnerOrAdmin(id)) return Forbid();

            var studentDTO = mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }

        //[Authorize(Roles = "admin")]
        [AllowAnonymous]
        [HttpPost("addStudent", Name = "addStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddStudentAsync([FromForm] AddStudentDTO studentDTO)
        {

            string pathImg = await fileService.UploadImg(studentDTO.Img, "students");

            var newStudent = mapper.Map<Student>(studentDTO);
            newStudent.ImgPath = pathImg;

          await studentRepository.AddStudentAsync(newStudent);

            var newStudentDTO = mapper.Map<StudentDTO>(newStudent);


            return CreatedAtRoute("getStudentById", new { id = newStudent.Id }, newStudentDTO);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("updateStudent", Name = "updateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> UpdateStudentAsync( [FromForm] UpdateStudentDTO studentDTO)
        {
            if (studentDTO.Id <= 0) return BadRequest("Mismatched ID");

            var existStudent = await studentRepository.GetStudentByIdAsync(studentDTO.Id);
            if (existStudent == null) return NotFound("not found student");


            string pathImg= existStudent.ImgPath;

            if (studentDTO.Img!=null )
            {
                pathImg = await fileService.UploadImg(studentDTO.Img, "students");
                await fileService.DeleteImg(existStudent.ImgPath);
            }


            mapper.Map(studentDTO, existStudent);
            existStudent.ImgPath = pathImg;

            await studentRepository.UpdateStudentAsync(existStudent);

            var updateStudentDTO = mapper.Map<StudentDTO>(existStudent);

            return Ok(updateStudentDTO);

        }

        [Authorize(Roles = "admin")]
        [HttpDelete("deleteStudent/{id}", Name = "deleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            if (id <= 0) return BadRequest("invalid id.");

            var existStudent = await studentRepository.GetStudentByIdAsync(id);
            if (existStudent == null) return NotFound("not found.");

            await fileService.DeleteImg(existStudent.ImgPath);

            await studentRepository.DeleteStudentAsync(existStudent);
            return Ok("deleted successfullt");
        }
    }

}
